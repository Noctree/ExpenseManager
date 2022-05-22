using ExpenseManager.DataObjects;
using ExpenseManager.DataObjects.Conversion;
using ExpenseManager.SQLite;

namespace ExpenseManager;

public class ExpensesDAO : IDisposable
{
    private const string CategoryTableName = "Categories";
    private const string ExpensesTableName = "Expenses";
    private readonly SQLiteConnection dbConnection;
    private readonly SqlTable categoriesTable;
    private readonly SqlTable transactionsTable;

    private CategoryList? cachedCategories;
    private bool categoriesChanged;

    public IObjectSqlDeconstructor<Transaction> TransactionDeconstructor { get; }
    public IObjectSqlDeconstructor<Category> CategoryDeconstructor { get; }
    public IObjectSqlReconstructor<Transaction> TransactionReconstructor { get; }
    public IObjectSqlReconstructor<Category> CategoryReconstructor { get; }
    public bool Disposed { get; private set; }

    public string Name => dbConnection.DataSource;
    public Category DefaultCategory { get; }

    public ExpensesDAO(SQLiteConnection connection) {
        dbConnection = connection;
        var categoryTableDescriptor = new SqlTableDescriptor(new SqlText("name"), new SqlColor("color"), new SqlText("description"), new SqlPrimaryKey());
        var transactionTableDescriptor = new SqlTableDescriptor(new SqlDateOnly("date"), new SqlDecimal("amount"), new SqlInteger("category"), new SqlText("description"), new SqlPrimaryKey());
        categoriesTable = new SqlTable(new SQLiteConnection(dbConnection), CategoryTableName, categoryTableDescriptor);
        transactionsTable = new SqlTable(new SQLiteConnection(dbConnection), ExpensesTableName, transactionTableDescriptor);
        CategoryDeconstructor = new SqlCategoryDeconstructor(categoriesTable.ColumnNames.Take(3));
        TransactionDeconstructor = new SqlTransactionDeconstructor(transactionsTable.ColumnNames.Take(4));
        CategoryReconstructor = new SqlCategoryReconstructor();
        TransactionReconstructor = new SqlTransactionReconstructor();

        var globalDefaultCategory = Category.Default;
        if (categoriesTable.Create()) {
            if (AddCategory(globalDefaultCategory, out var addedDefaultCategory))
                DefaultCategory = addedDefaultCategory!;
            else
                throw new ApplicationException("Failed to create default category");
        }
        else if (TryGetCategory(globalDefaultCategory.Name, out var localDefaultCategory))
            DefaultCategory = localDefaultCategory;
        else
            throw new ApplicationException("Failed to load default category");
        transactionsTable.Create();
    }

    public CategoryList GetCategories() {
        if (cachedCategories is null || categoriesChanged) {
            cachedCategories = GetCategories_Internal();
            categoriesChanged = false;
        }
        return cachedCategories;
    }

    private CategoryList GetCategories_Internal() {
        var categories = new CategoryList();
        var columns = categoriesTable.GetRow(categoriesTable.ColumnNames);
        categories.EnsureCapacity(columns.Count);
        foreach (var column in columns) {
            var category = CategoryReconstructor.ReconstructObject(column);
            if (category.Id is null)
                throw new SQLiteException("Category retrieved from database has missing ID");
            categories.Add(category);
        }
        return categories;
    }

    public bool TryGetCategory(string categoryName, out Category category) {
        category = Category.Default;
        var columns = categoriesTable.GetRowsWhere($"name = '{categoryName}'", categoriesTable.ColumnNames);
        if (columns.Count == 0)
            return false;
        category = CategoryReconstructor.ReconstructObject(columns[0]);
        return true;
    }

    public bool AddCategories(IReadOnlyList<Category> categories, out CategoryList addedcategories) {
        categoriesChanged = true;
        addedcategories = new();
        var result = categoriesTable.InsertRows(CategoryDeconstructor, categories) == categories.Count;
        var lastId = categoriesTable.GetLastPrimaryKeyId();
        if (result) {
            for (int i = categories.Count - 1; i >= 0; i--) {
                addedcategories.Add(new Category(categories[i], lastId));
                --lastId;
            }
            addedcategories.Reverse();
        }
        return result;
    }

    public bool AddCategory(Category category, out Category? addedCategory) {
        categoriesChanged = true;
        var result = categoriesTable.InsertRow(CategoryDeconstructor, category) != 0;
        addedCategory = result ? new Category(category, categoriesTable.GetLastPrimaryKeyId()) : null;
        return result;
    }

    public bool AddTransaction(Transaction transaction, out Transaction? addedTransaction) {
        var result = transactionsTable.InsertRow(TransactionDeconstructor, transaction) != 0;
        addedTransaction = result ? new Transaction(transaction, transactionsTable.GetLastPrimaryKeyId()) : null;
        return result;
    }

    public bool AddTransactions(IReadOnlyList<Transaction> transactions, out List<Transaction> addedTransactions) {
        var result = transactionsTable.InsertRows(TransactionDeconstructor, transactions) == transactions.Count;
        addedTransactions = new List<Transaction>();
        var lastId = transactionsTable.GetLastPrimaryKeyId();
        if (result) {
            for (int i = transactions.Count - 1; i >= 0; i--) {
                addedTransactions.Add(new Transaction(transactions[i], lastId));
                --lastId;
            }
            addedTransactions.Reverse();
        }
        return result;
    }

    public List<Transaction> GetTransactions() {
        var transactions = new List<Transaction>();
        var categories = GetCategories();
        var columns = transactionsTable.GetRow(transactionsTable.ColumnNames);
        transactions.EnsureCapacity(columns.Count);
        foreach (var column in columns) {
            var transaction = TransactionReconstructor.ReconstructObject(column);
            var category = categories.GetById((int)(long)column[2]);
            if (category is null)
                throw new SQLiteException($"Transaction {transaction.Id} references a non-existant category with ID {column[2]}. Database is probably corrupted");
            transaction.Category = category;
            transactions.Add(transaction);
        }
        return transactions;
    }

    public Task<List<Transaction>> GetTransactionsAsync() => Task.Run(GetTransactions);

    public Task<CategoryList> GetCategoriesAsync() => Task.Run(GetCategories);

    public bool UpdateTransaction(Transaction transaction) => transactionsTable.UpdateRow(TransactionDeconstructor, transaction) != 0;
    public bool UpdateCategory(Category category) => categoriesTable.UpdateRow(CategoryDeconstructor, category) != 0;

    public bool DeleteTransaction(Transaction transaction) {
        var result = transactionsTable.DeleteRow(TransactionDeconstructor, transaction) != 0;
        if (result)
            transaction.Invalidate();
        return result;
    }
    public bool DeleteCategory(Category category) {
        var result = categoriesTable.DeleteRow(CategoryDeconstructor, category) != 0;
        if (result)
            category.Invalidate();
        categoriesChanged = true;
        return result;
    }
    public bool DeleteTransactions(IReadOnlyList<Transaction> transactions) {
        if (transactions.Count == 0)
            return true;
        if (transactions.Count == 1)
            return DeleteTransaction(transactions[0]);
        var result = transactionsTable.DeleteRows(TransactionDeconstructor, transactions) == transactions.Count;
        if (result) {
            foreach (var transaction in transactions)
                transaction.Invalidate();
        }

        return result;
    }
    public bool DeleteCategories(IReadOnlyList<Category> categories) {
        if (categories.Count == 0)
            return true;
        if (categories.Count == 1)
            return DeleteCategory(categories[0]);
        foreach (var category in categories)
            transactionsTable.ExecuteRawSQL($"UPDATE {transactionsTable.TableName} SET category = {DefaultCategory.Id} WHERE category = {category.Id ?? -1};");
        var result = transactionsTable.DeleteRows(CategoryDeconstructor, categories) == categories.Count;
        if (result) {
            foreach (var category in categories)
                category.Invalidate();
        }

        categoriesChanged = true;
        return result;
    }

    protected virtual void Dispose(bool disposing) {
        if (!Disposed) {
            if (disposing) {
                // TODO: dispose managed state (managed objects)
            }

            dbConnection.Close();
            dbConnection.Dispose();
            categoriesTable.Dispose();
            transactionsTable.Dispose();
            Disposed = true;
        }
    }
    ~ExpensesDAO() {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose() {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

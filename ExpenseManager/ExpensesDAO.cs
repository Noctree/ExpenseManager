﻿using ExpenseManager.DataObjects;
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

    private readonly IObjectDeconstructor<Category> categoryDeconstructor;
    private readonly IObjectDeconstructor<Transaction> transactionDeconstructor;
    private readonly IObjectReconstructor<Category> categoryReconstructor;
    private readonly IObjectReconstructor<Transaction> transactionReconstructor;

    private List<Category>? cachedCategories;
    private bool categoriesChanged;

    private bool disposedValue;
    public IObjectDeconstructor<Transaction> TransactionDeconstructor => transactionDeconstructor;
    public IObjectDeconstructor<Category> CategoryDeconstructor => categoryDeconstructor;
    public bool Disposed => disposedValue;

    public string Name => dbConnection.DataSource;
    public Category DefaultCategory { get; }

    public ExpensesDAO(SQLiteConnection connection) {
        dbConnection = connection;
        var categoryTableDescriptor = new SqlTableDescriptor(new SqlText("name"), new SqlColor("color"), new SqlText("description"), new SqlPrimaryKey());
        var transactionTableDescriptor = new SqlTableDescriptor(new SqlDateOnly("date"), new SqlDecimal("amount"), new SqlInteger("category"), new SqlText("description"), new SqlPrimaryKey());
        categoriesTable = new SqlTable(new SQLiteConnection(dbConnection), CategoryTableName, categoryTableDescriptor);
        transactionsTable = new SqlTable(new SQLiteConnection(dbConnection), ExpensesTableName, transactionTableDescriptor);
        categoryDeconstructor = new CategoryDeconstructor(categoriesTable.ColumnNames.Take(3));
        transactionDeconstructor = new TransactionDeconstructor(transactionsTable.ColumnNames.Take(4));
        categoryReconstructor = new CategoryReconstructor();
        transactionReconstructor = new TransactionReconstructor();

        var globalDefaultCategory = Category.Default;
        if (categoriesTable.Create()) {
            if (AddCategory(globalDefaultCategory, out var addedDefaultCategory))
                DefaultCategory = addedDefaultCategory!;
            else
                throw new ApplicationException("Failed to create default category");
        } else {
            if (TryGetCategory(globalDefaultCategory.Name, out var localDefaultCategory))
                DefaultCategory = localDefaultCategory;
            else
                throw new ApplicationException("Failed to load default category");
        }
        transactionsTable.Create();
    }

    public List<Category> GetCategories() {
        if (cachedCategories is null || categoriesChanged) {
            cachedCategories = GetCategories_Internal();
            categoriesChanged = false;
        }
        return cachedCategories;
    }

    private List<Category> GetCategories_Internal() {
        var categories = new List<Category>();
        var columns = categoriesTable.GetRow(categoriesTable.ColumnNames);
        categories.EnsureCapacity(columns.Count);
        foreach (var column in columns)
            categories.Add(categoryReconstructor.ReconstructObject(column));
        return categories;
    }

    public bool TryGetCategory(string categoryName, out Category category) {
        category = Category.Default;
        var columns = categoriesTable.GetRowsWhere($"name = '{categoryName}'", categoriesTable.ColumnNames);
        if (columns.Count == 0)
            return false;
        category = categoryReconstructor.ReconstructObject(columns[0]);
        return true;
    }

    public bool AddCategories(IReadOnlyList<Category> categories, out List<Category> addedcategories) {
        categoriesChanged = true;
        addedcategories = new List<Category>();
        var result = categoriesTable.InsertRows(categoryDeconstructor, categories) == categories.Count;
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
        var result = categoriesTable.InsertRow(categoryDeconstructor, category) != 0;
        addedCategory = result ? new Category(category, categoriesTable.GetLastPrimaryKeyId()) : null;
        return result;
    }

    public bool AddTransaction(Transaction transaction, out Transaction? addedTransaction) {
        var result = transactionsTable.InsertRow(transactionDeconstructor, transaction) != 0;
        addedTransaction = result? new Transaction(transaction, transactionsTable.GetLastPrimaryKeyId()) : null;
        return result;
    }

    public bool AddTransactions(IReadOnlyList<Transaction> transactions, out List<Transaction> addedTransactions) {
        var result = transactionsTable.InsertRows(transactionDeconstructor, transactions) == transactions.Count;
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
            var transaction = transactionReconstructor.ReconstructObject(column);
            transaction.Category = categories[(int)(long)column[2] - 1];
            transactions.Add(transaction);
        }
        return transactions;
    }

    public Task<List<Transaction>> GetTransactionsAsync() => Task.Run(GetTransactions);

    public Task<List<Category>> GetCategoriesAsync() => Task.Run(GetCategories);

    public bool UpdateTransaction(Transaction transaction) => transactionsTable.UpdateRow(transactionDeconstructor, transaction) != 0;
    public bool UpdateCategory(Category category) => categoriesTable.UpdateRow(categoryDeconstructor, category) != 0;

    public bool DeleteTransaction(Transaction transaction) {
        var result = transactionsTable.DeleteRow(transactionDeconstructor, transaction) != 0;
        if (result)
            transaction.Id = -1;
        return result;
    }
    public bool DeleteCategory(Category category) {
        var result = categoriesTable.DeleteRow(categoryDeconstructor, category) != 0;
        if (result)
            category.Id = -1;
        categoriesChanged = true;
        return result;
    }
    public bool DeleteTransactions(IReadOnlyList<Transaction> transactions) {
        if (transactions.Count == 0)
            return true;
        if (transactions.Count == 1)
            return DeleteTransaction(transactions[0]);
        var result = transactionsTable.DeleteRows(transactionDeconstructor, transactions) == transactions.Count;
        if (result)
            foreach (var transaction in transactions)
                transaction.Id = -1;
        return result;
    }
    public bool DeleteCategories(IReadOnlyList<Category> categories) {
        if (categories.Count == 0)
            return true;
        if (categories.Count == 1)
            return DeleteCategory(categories[0]);
        foreach (var category in categories)
            transactionsTable.ExecuteRawSQL($"UPDATE {transactionsTable.TableName} SET category = {DefaultCategory.Id} WHERE category = {category.Id ?? -1};");
        var result = transactionsTable.DeleteRows(categoryDeconstructor, categories) == categories.Count;
        if (result)
            foreach (var category in categories)
                category.Id = -1;
        categoriesChanged = true;
        return result;
    }

    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                // TODO: dispose managed state (managed objects)
            }

            dbConnection.Dispose();
            categoriesTable.Dispose();
            transactionsTable.Dispose();
            disposedValue = true;
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
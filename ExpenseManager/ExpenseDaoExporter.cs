using System.IO;
using ExpenseManager.CSV;
using ExpenseManager.DataObjects;
using ExpenseManager.DataObjects.Conversion;

namespace ExpenseManager;
public static class ExpenseDaoExporter
{
    public static async Task ExportExpensesDaoAsync(string filePath, ExpensesDAO dao) {
        await CsvExporter.ExportAsync(filePath, new CsvTransactionDeconstructor(dao.TransactionDeconstructor.ColumnNames), dao.GetTransactions());
        var categoriesFileName = Path.Combine(Path.GetDirectoryName(filePath) ?? string.Empty, Path.GetFileNameWithoutExtension(filePath) + "-categories.csv");
        await CsvExporter.ExportAsync(categoriesFileName, new CsvCategoryDeconstructor(dao.CategoryDeconstructor.ColumnNames), dao.GetCategories());
    }

    public static async Task ImportExpensesDaoAsync(string transactionsFilePath, string categoriesFilePath, string username, DatabaseManager dbManager) {
        dbManager.CreateNewUser(username);
        var dao = dbManager.OpenUser(username);
        var categories = await CsvExporter.ImportAsync(categoriesFilePath, new CsvCategoryReconstructor());
        if (dao.AddCategories(categories, out var addedCategories))
            throw new SQLiteException($"Categories were imported successfully from {categoriesFilePath}.\nBut saving them into {username} failed");
        var transactions = await CsvExporter.ImportAsync(transactionsFilePath, new CsvTransactionReconstructor(addedCategories));
        if (!dao.AddTransactions(transactions, out var _))
            throw new SQLiteException($"Transactions were imported successfully from {transactionsFilePath}.\nBut saving them into {username} failed");
        dbManager.CloseUser(username);
    }
}

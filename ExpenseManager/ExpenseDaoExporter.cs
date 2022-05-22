using System.IO;
using ExpenseManager.CSV;
using ExpenseManager.DataObjects;
using ExpenseManager.DataObjects.Conversion;

namespace ExpenseManager;
public static class ExpenseDaoExporter {
    public static async Task ExportExpensesDaoAsync(string filePath, ExpensesDAO dao) {
        await CsvExporter.ExportAsync(filePath, new CsvTransactionDeconstructor(dao.TransactionDeconstructor.ColumnNames), dao.GetTransactions());
        var categoriesFileName = GetCategoryFileName(filePath);
        await CsvExporter.ExportAsync(categoriesFileName, new CsvCategoryDeconstructor(dao.CategoryDeconstructor.ColumnNames), dao.GetCategories().Skip(1)); //Skip the 1st default category, as it supposed to be hidden from the user and gets added by default anyway
    }

    public static string GetCategoryFileName(string filePath) {
        return Path.Combine(Path.GetDirectoryName(filePath) ?? string.Empty, Path.GetFileNameWithoutExtension(filePath) + "-categories.csv");
    }

    public static async Task ImportExpensesDaoAsync(string transactionsFilePath, string categoriesFilePath, string username, DatabaseManager dbManager) {
        dbManager.CreateNewUser(username);
        var dao = dbManager.OpenUser(username);
        var categories = await CsvExporter.ImportAsync(categoriesFilePath, new CsvCategoryReconstructor());
        if (!dao.AddCategories(categories, out var _))
            throw new SQLiteException($"Categories were imported successfully from {categoriesFilePath}.\nBut saving them into {username} failed");
        categories = await dao.GetCategoriesAsync();
        var transactions = await CsvExporter.ImportAsync(transactionsFilePath, new CsvTransactionReconstructor(categories));
        if (!dao.AddTransactions(transactions, out var _))
            throw new SQLiteException($"Transactions were imported successfully from {transactionsFilePath}.\nBut saving them into {username} failed");
        dbManager.CloseUser(username);
    }
}

namespace Tests;

public class CsvExporterTests
{
    [Fact]
    public void RandomDatabaseExportAndImport() {
        var exportUsername = "Export Test";
        var importUsername = "Import Test";

        var exportFileName = "ExportTest.csv";

        var dbManager = new DatabaseManager(Constants.DatabasesPath);
        dbManager.CreateNewUser(exportUsername);
        var dao = dbManager.OpenUser(exportUsername);
        DataGenerator.GenerateDatabase(dao, 25, 1000);

        ExpenseDaoExporter.ExportExpensesDaoAsync(exportFileName, dao).Wait();

        ExpenseDaoExporter.ImportExpensesDaoAsync(exportFileName, ExpenseDaoExporter.GetCategoryFileName(exportFileName), importUsername, dbManager).Wait();

        var importDao = dbManager.OpenUser(importUsername);

        var originalCategories = dao.GetCategories();
        var importCategories = importDao.GetCategories();

        Assert.Equal(originalCategories.Count, importCategories.Count);
        for (int i = 0; i < originalCategories.Count; i++)
            Assert.True(Category.AreEqual(originalCategories[i], importCategories[i]));

        var originalTransactions = dao.GetTransactions();
        var importedTransactions = importDao.GetTransactions();

        Assert.Equal(originalTransactions.Count, importedTransactions.Count);
        for (int i = 0; i < importedTransactions.Count; i++)
            Assert.True(Transaction.AreEqual(originalTransactions[i], importedTransactions[i]));
    }
}
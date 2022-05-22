using ExpenseManager.DataObjects;
using ExpenseManager.UI;

namespace ExpenseManager;

internal static class Program
{
    private const string DatabasePath = "Data/";
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
        ////Task.Run(TestingAsyncStuff).Wait();
        ////return;
        GenerateExampleDatabaseHuge();
        GenerateExampleDatabase();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    private static void GenerateExampleDatabase() {
        var username = "Example";
        var manager = new DatabaseManager(DatabasePath);
        if (manager.UserExists(username))
            return;
        manager.CreateNewUser(username);
        var dao = manager.OpenUser(username);
        DataGenerator.GenerateDatabase(dao, 10, 1000);
        manager.CloseUser(username);
    }

    private static void GenerateExampleDatabaseHuge() {
        var username = "Big Data";
        var manager = new DatabaseManager(DatabasePath);
        if (manager.UserExists(username))
            return;
        manager.CreateNewUser(username);
        var dao = manager.OpenUser(username);
        DataGenerator.GenerateDatabase(dao, 40, 100_000);
        manager.CloseUser(username);
    }

    private static async Task TestingAsyncStuff() {
        var dbManager = new DatabaseManager(DatabasePath);
        var dao = dbManager.OpenUser("Example");
        Console.WriteLine("Await transactions BEGIN");
        var transactions = await dao.GetTransactionsAsync();
        Console.WriteLine("Await transactions END");
        Console.WriteLine(transactions.Count);
    }
    private static void Testing() {
        Console.WriteLine("Create Database manager");
        var dbmanager = new DatabaseManager(DatabasePath);

        Console.WriteLine("Load existing users");
        dbmanager.DeleteAllDatabases();
        Console.WriteLine("Users:");
        foreach (var user in dbmanager.Users)
            Console.WriteLine(user);
        Console.WriteLine("\n\nCreate new user");
        Console.Write("Username: ");
        string input = Console.ReadLine() ?? "NULL";
        dbmanager.CreateNewUser(input);
        var dao = dbmanager.OpenUser(input);

        Console.WriteLine("\n\nTest Category addition");
        for (int i = 0; i < 5; i++) {
            var generatedCategory = DataGenerator.GenerateCategory();
            Console.WriteLine(generatedCategory);
            dao.AddCategory(generatedCategory, out var _);
        }

        Console.WriteLine("\n\nTest Category getter");
        Console.WriteLine("\nGetCategories");
        var categories = dao.GetCategories();
        foreach (var _ in categories)
            Console.WriteLine(_);

        Console.WriteLine("\n\nTest Category get by name");
        Console.Write("Category name: ");
        input = Console.ReadLine() ?? "NULL";
        var category = new Category(input);

        Console.WriteLine("Insert");
        dao.AddCategory(category, out var _);
        Console.WriteLine("Get");
        if (dao.TryGetCategory(category.Name, out var daoCategory))
            Console.WriteLine(daoCategory);
        else
            Console.WriteLine("Failed to get the category");

        Console.WriteLine("\n\n\nTransactions test");
        Console.WriteLine("Add transactions");
        for (int i = 0; i < 10; i++) {
            var generatedTransaction = DataGenerator.GenerateTransaction(categories[i % categories.Count]);
            Console.WriteLine(generatedTransaction);
            dao.AddTransaction(generatedTransaction, out var _);
        }

        Console.WriteLine("\nDone");
        Console.ReadKey();
    }
}
using ExpenseManager;
using Tests;

namespace Database_Generator;

internal class Program
{
    private static void Main(string[] args) {
        Console.Write("Database folder path: ");
        string folder = Console.ReadLine() ?? String.Empty;
        if (!Directory.Exists(folder))
            ExitWithError("Folder path is invalid");

        Console.Write("Account name: ");
        string name = Console.ReadLine() ?? String.Empty;

        var dbmanager = new DatabaseManager(folder);
        if (dbmanager.UserExists(name))
            ExitWithError("Account with that name already exists!");
        dbmanager.CreateNewUser(name);
        var dao = dbmanager.OpenUser(name);

        Console.Write("Category count: ");
        string input = Console.ReadLine() ?? string.Empty;
        if (!int.TryParse(input, out int categoryCount))
            ExitWithError("Invalid input");

        Console.Write("Transaction count: ");
        input = Console.ReadLine() ?? String.Empty;
        if (!int.TryParse(input, out int transactionCount))
            ExitWithError("Invalid input");

        Console.WriteLine("Generating...");
        DataGenerator.GenerateDatabase(dao, categoryCount, transactionCount);
        dbmanager.CloseAllUsers();
        Console.WriteLine("Done");
    }

    private static void ExitWithError(string message) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ReadKey();
        Environment.Exit(1);
    }
}

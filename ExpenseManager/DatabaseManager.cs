using System.Diagnostics;
using System.IO;
using ExpenseManager.SQLite;

namespace ExpenseManager;

public class DatabaseManager
{
    private const string DatabaseExtension = "expensedb";
    private static string FolderSearchPattern => "*." + DatabaseExtension;

    private readonly List<string> databases = new();
    private readonly Dictionary<string, ExpensesDAO> openUsers = new();
    public string DatabaseDirectory { get; }
    public IReadOnlyCollection<string> Users => databases.AsReadOnly();
    public IReadOnlyCollection<string> OpenedUsers => openUsers.Keys.ToList().AsReadOnly();
    public DatabaseManager(string databaseDirectoryPath) {
        DatabaseDirectory = databaseDirectoryPath;
        if (!Directory.Exists(DatabaseDirectory))
            Directory.CreateDirectory(DatabaseDirectory);
        else
            LoadAvailableDatabases();
    }

    public void DeleteAllDatabases() {
        Debug.WriteLine("[DatabaseManager]: Deleting all databases");
        while (databases.Count > 0)
            DeleteUser(databases[0]);
    }

    private void LoadAvailableDatabases() {
        Debug.WriteLine($"[DatabaseManager]: Searching {Path.Combine(Environment.CurrentDirectory, DatabaseDirectory)} for databases");
        var search = Directory.GetFiles(DatabaseDirectory, FolderSearchPattern);
        for (int i = 0; i < search.Length; i++)
            search[i] = Path.GetFileNameWithoutExtension(search[i]);
        databases.AddRange(search);
    }

    public bool ContainsUser(string username) => databases.Contains(username);
    public bool IsUserOpen(string username) => openUsers.ContainsKey(username);

    public void CreateNewUser(string username) {
        if (ContainsUser(username))
            throw new ArgumentException("User already exists");
        databases.Add(username);
        SQLiteConnection.CreateFile(DatabasePathFromUsername(username));
    }

    public void DeleteUser(string username) {
        if (ContainsUser(username)) {
            if (IsUserOpen(username))
                CloseUser(username);
            foreach (var file in Directory.GetFiles(DatabaseDirectory, $"{username}.*"))
                File.Delete(file);
            databases.Remove(username);
        }
    }

    public ExpensesDAO OpenUser(string username) {
        if (!ContainsUser(username))
            throw new ArgumentException("User does not exist");
        if (IsUserOpen(username))
            throw new ArgumentException("User database is already opened");
        var dao = new ExpensesDAO(CreateConnection(username));
        openUsers.Add(username, dao);
        return dao;
    }

    public void CloseUser(string username) {
        if (!IsUserOpen(username))
            return;
        Debug.WriteLine("Closing user " + username);
        var dao = openUsers[username];
        if (!dao.Disposed)
            dao.Dispose();
        openUsers.Remove(username);
    }

    public void CloseAllUsers() {
        Debug.WriteLine("Closing all opened users...");
        var list = openUsers.Keys.ToList();
        foreach (var user in list)
            CloseUser(user);
    }

    private string DatabasePathFromUsername(string username) => Path.Combine(DatabaseDirectory, string.Concat(username, ".", DatabaseExtension));

    /// <summary>
    /// Creates new SQLite database connection. According to System.Data.SQLite
    /// <see href="https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/async"> documentation </see>
    /// , the async methods are useless. Since SQLite does not support async operations the "async" versions just execute synchronously.
    /// Instead this method sets the connection up in the recommended way for best performance
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    private SQLiteConnection CreateConnection(string username) {
        var fileName = DatabasePathFromUsername(username);
        var db = new SQLiteConnection($"Data Source={fileName};Cache=Shared;");
        using (var _ = db.OpenAsTemporaryConnection()) {
            var command = db.CreateCommand();
            command.CommandText = "PRAGMA journal_mode = 'wal'";
            command.ExecuteNonQuery();
            command.Dispose();
        }
        return db;
    }
}

namespace ExpenseManager.SQLite;

/// <summary>
/// Wrapper around SQLiteConnection, enables usage with 'using' syntax to automatically open and close the connection
/// </summary>
public class TemporaryConnection : IDisposable
{
    private SQLiteConnection connection;
    public TemporaryConnection(SQLiteConnection connection) {
        this.connection = connection;
        connection.Open();
    }

    public void Dispose() {
        connection.Close();
        GC.SuppressFinalize(this);
    }
}

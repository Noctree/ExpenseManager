namespace ExpenseManager.SQLite;

public class SqlTable : IDisposable {
    private SqlTableDescriptor descriptor;
    private bool disposedValue;

    public SQLiteConnection Connection { get; }
    public string TableName { get; }
    public SqlTableDescriptor TableDescriptor => descriptor;
    public IReadOnlyList<ISqlColumnDescriptor> ColumnTypes => descriptor.Descriptors;
    public IReadOnlyList<string> ColumnNames => descriptor.Names;
    public SqlTable(SQLiteConnection databaseConnection, string name, SqlTableDescriptor tableDescriptor) {
        TableName = name;
        Connection = databaseConnection;
        descriptor = tableDescriptor;
    }
    public bool Create() {
        using (var tempConnection = Connection.OpenAsTemporaryConnection()) {
            if (ContainsTable(Connection, TableName))
                return false;
            string command = SqlCommandGenerator.CreateTable(TableName, descriptor.Descriptors);
            var sqlCommand = new SQLiteCommand(command, Connection);
            sqlCommand.ExecuteNonQueryWithLogging();
            sqlCommand.Dispose();
        }
        return true;
    }

    public bool ContainsColumn(string name) => descriptor.ContainsDescriptorWithName(name);

    public List<object[]> GetRow(IReadOnlyList<string> columnNames) {
        var results = new List<object[]>();
        var descriptors = descriptor.GetDescriptorsByNames(columnNames);
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var sqlCommand = SqlCommandGenerator.CreateSelectCommand(this, columnNames);
            var command = Connection.CreateCommand();
            command.CommandText = sqlCommand;
            var reader = command.ExecuteReaderWithLogging();
            while (reader.Read()) {
                results.Add(ReadRow(reader, descriptors));
            }
            command.Dispose();
        }
        return results;
    }

    public List<object[]> GetRowsWhere(string predicate, params string[] columnNames) => GetRowsWhere(predicate, (IReadOnlyList<string>)columnNames);

    public List<object[]> GetRowsWhere(string predicate, IReadOnlyList<string> columnNames) {
        var results = new List<object[]>();
        var descriptors = descriptor.GetDescriptorsByNames(columnNames);
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = SqlCommandGenerator.CreateSelectCommandWithPredicate(this, columnNames, predicate);
            var reader = command.ExecuteReaderWithLogging();
            while (reader.Read()) {
                results.Add(ReadRow(reader, descriptors));
            }
            command.Dispose();
        }
        return results;
    }

    public int InsertRow<T>(IObjectSqlDeconstructor<T> deconstructor, T value) {
        int result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = SqlCommandGenerator.CreateInsertCommand(this, deconstructor, value);
            result = command.ExecuteNonQuery();
            command.Dispose();
        }
        return result;
    }

    public int InsertRow(params SqlParam[] parameters) {
        int result = 0;
        using (var tempConnection = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = SqlCommandGenerator.CreateInsertCommand(this, parameters);
            result = command.ExecuteNonQueryWithLogging();
            command.Dispose();
        }
        return result;
    }

    public int InsertRows<T>(IObjectSqlDeconstructor<T> deconstructor, IReadOnlyList<T> values) {
        int result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            var sqlCommand = SqlCommandGenerator.CreateInsertCommand(this, deconstructor, values);
            command.CommandText = sqlCommand;
            result = command.ExecuteNonQueryWithLogging();
            command.Dispose();
        }
        return result;
    }

    public int UpdateRow<T>(IObjectSqlDeconstructor<T> deconstructor, T value) {
        int result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = SqlCommandGenerator.CreateUpdateCommand(this, deconstructor, value);
            result = command.ExecuteNonQueryWithLogging();
            command.Dispose();
        }
        return result;
    }

    public int ExecuteRawSQL(string sqlCommand) {
        int result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = sqlCommand;
            result = command.ExecuteNonQueryWithLogging();
            command.Dispose();
        }
        return result;
    }

    public int DeleteRow<T>(IObjectSqlDeconstructor<T> deconstructor, T value) {
        int result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = SqlCommandGenerator.CreateDeleteCommandById(this, deconstructor, value);
            result = command.ExecuteNonQueryWithLogging();
            command.Dispose();
        }
        return result;
    }

    public int DeleteRows<T>(IObjectSqlDeconstructor<T> deconstructor, IReadOnlyList<T> values) {
        int result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = SqlCommandGenerator.CreateDeleteCommandByIdMultiple(this, deconstructor, values);
            result = command.ExecuteNonQueryWithLogging();
            command.Dispose();
        }
        return result;
    }
    public long GetLastPrimaryKeyId() {
        long result = 0;
        using (var _ = Connection.OpenAsTemporaryConnection()) {
            var command = Connection.CreateCommand();
            command.CommandText = $"SELECT MAX({TableDescriptor.PrimaryKey.Name}) FROM {TableName}";
            var reader = command.ExecuteReaderWithLogging();
            reader.Read();
            result = reader.GetInt64(0);
            reader.Close();
            command.Dispose();
        }
        return result;
    }

    private object[] ReadRow(SQLiteDataReader reader, IReadOnlyList<ISqlColumnDescriptor> descriptors) {
        var objects = new object[reader.FieldCount];
        for (int i = 0; i < reader.FieldCount; i++) {
            var descriptor = descriptors[i];
            objects[i] = descriptor.Converter.FromSql(reader.GetValue(i));
        }
        return objects;
    }

    private static bool ContainsTable(SQLiteConnection connection, string tableName) {
        var command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';", connection);
        var reader = command.ExecuteReader();
        bool result = reader.HasRows;
        reader.Close();
        reader.Dispose();
        command.Dispose();
        return result;
    }


    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                // TODO: dispose managed state (managed objects)
            }

            descriptor = null!;
            Connection.Dispose();
            disposedValue = true;
        }
    }
    ~SqlTable() {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose() {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

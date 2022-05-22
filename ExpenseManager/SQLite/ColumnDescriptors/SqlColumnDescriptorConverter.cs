namespace ExpenseManager.SQLite;

internal static class SqlColumnDescriptorConverter
{
    private const string UniqueKeyword = "UNIQUE";
    private const string NotNullKeyword = "NOT NULL";
    private const string AutoIncrementKeyword = "AUTOINCREMENT";
    private const string PrimaryKeyKeyword = "PRIMARY KEY";
    private static readonly StringBuilder sb = new();
    public static string ToSqlColumnDefinition(ISqlColumnDescriptor value) {
        const char space = ' ';
        sb.Clear();
        sb.Append(value.Name);
        sb.Append(space);
        sb.Append(value.SqlType);
        if (value.IsPrimaryKey) {
            sb.Append(space);
            sb.Append(PrimaryKeyKeyword);
        }
        if (value.AutoIncrement) {
            sb.Append(space);
            sb.Append(AutoIncrementKeyword);
        }
        if (value.Unique) {
            sb.Append(space);
            sb.Append(UniqueKeyword);
        }
        if (value.NotNull) {
            sb.Append(space);
            sb.Append(NotNullKeyword);
        }
        return sb.ToString();
    }
}

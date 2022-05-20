namespace ExpenseManager.SQLite;

public interface ISqlColumnDescriptor
{
    protected const string SqlType_Integer = "INTEGER";
    protected const string SqlType_Text = "TEXT";
    protected const string SqlType_Numeric = "NUMERIC";
    protected const string SqlType_Real = "REAL";
    public string Name { get; }
    public string SqlType { get; }
    public bool NotNull { get; }
    public bool Unique { get; }
    public bool IsPrimaryKey { get; }
    public bool AutoIncrement { get; }
    public ISqlConverter Converter { get; }
    public string ToSqlColumnDefinition();
}

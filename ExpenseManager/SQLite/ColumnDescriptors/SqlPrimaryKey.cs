namespace ExpenseManager.SQLite;

public class SqlPrimaryKey : ISqlColumnDescriptor, ISqlConverter<long>
{
    private const string PrimaryKeyName = "ID";
    public string Name { get; set; }
    public string SqlType => ISqlColumnDescriptor.SqlType_Integer;
    public bool IsPrimaryKey => true;
    public bool AutoIncrement => true;
    public bool NotNull => false;
    public bool Unique => true;

    public ISqlConverter Converter => this;

    public SqlPrimaryKey(string name = PrimaryKeyName) {
        Name = name;
    }

    public string ToSqlColumnDefinition() => $"{Name} INTEGER PRIMARY KEY AUTOINCREMENT";

    public long FromSql(object sqlValue) => (long)sqlValue;

    public string ToSql(long value) => value.ToString();

    object ISqlConverter.FromSql(object sqlValue) => (long)sqlValue;

    public string ToSql(object value) => ((long)value).ToString();
}

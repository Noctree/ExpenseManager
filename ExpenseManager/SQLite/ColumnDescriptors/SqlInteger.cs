namespace ExpenseManager.SQLite;

public class SqlInteger : ISqlColumnDescriptor, ISqlConverter<long>
{
    private const string sqlType = "INTEGER";
    public string SqlType => sqlType;
    public string Name { get; }
    public bool NotNull { get; set; } = true;
    public bool Unique { get; set; }
    public bool IsPrimaryKey { get; set; }
    public bool AutoIncrement { get; set; }
    public ISqlConverter Converter => this;

    public SqlInteger(string name) {
        Name = name;
    }

    public string ToSqlColumnDefinition() => SqlColumnDescriptorConverter.ToSqlColumnDefinition(this);

    public long FromSql(object sqlValue) => (long)sqlValue;

    public string ToSql(long value) => value.ToString(ISqlConverter.InvariantCulture);

    object ISqlConverter.FromSql(object sqlValue) => (long)sqlValue;

    public string ToSql(object value) => ((long)value).ToString(ISqlConverter.InvariantCulture);
}

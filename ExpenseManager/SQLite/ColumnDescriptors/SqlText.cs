namespace ExpenseManager.SQLite;

public class SqlText : ISqlColumnDescriptor, ISqlConverter<string>
{
    public string Name { get; set; }
    public string SqlType => ISqlColumnDescriptor.SqlType_Text;
    public bool NotNull { get; set; }
    public bool Unique { get; set; }
    public bool IsPrimaryKey => false;
    public bool AutoIncrement => false;
    public ISqlConverter Converter => this;

    public SqlText(string name) {
        Name = name;
    }

    public string ToSqlColumnDefinition() => SqlColumnDescriptorConverter.ToSqlColumnDefinition(this);

    public string FromSql(object sqlValue) => (string)sqlValue;

    public string ToSql(string value) => ISqlConverter.StringToSqlString(value);

    object ISqlConverter.FromSql(object sqlValue) => sqlValue;

    public string ToSql(object value) => ISqlConverter.StringToSqlString((string)value);
}

namespace ExpenseManager.SQLite;

public class SqlDateOnly : ISqlColumnDescriptor, ISqlConverter<DateOnly>
{
    public string Name { get; set; }
    public string SqlType => ISqlColumnDescriptor.SqlType_Integer;
    public bool NotNull { get; set; }
    public bool Unique { get; set; }
    public bool IsPrimaryKey => false;
    public bool AutoIncrement => false;
    public ISqlConverter Converter => this;

    public SqlDateOnly(string name) {
        Name = name;
    }

    public string ToSqlColumnDefinition() => SqlColumnDescriptorConverter.ToSqlColumnDefinition(this);

    public DateOnly FromSql(object sqlValue) => DateOnly.FromDayNumber((int)(long)sqlValue);

    public string ToSql(DateOnly value) => value.DayNumber.ToString(ISqlConverter.InvariantCulture);

    object ISqlConverter.FromSql(object sqlValue) => FromSql((long)sqlValue);

    public string ToSql(object value) => ((DateOnly)value).DayNumber.ToString(ISqlConverter.InvariantCulture);
}

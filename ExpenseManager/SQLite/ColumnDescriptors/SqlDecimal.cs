namespace ExpenseManager.SQLite;

public class SqlDecimal : ISqlColumnDescriptor, ISqlConverter<decimal>
{
    public string Name { get; }
    public string SqlType => ISqlColumnDescriptor.SqlType_Numeric;
    public bool NotNull { get; set; }
    public bool Unique { get; set; }
    public bool IsPrimaryKey => false;
    public bool AutoIncrement => false;
    public ISqlConverter Converter => this;

    public SqlDecimal(string name) {
        Name = name;
    }

    public string ToSqlColumnDefinition() => SqlColumnDescriptorConverter.ToSqlColumnDefinition(this);

    public decimal FromSql(object sqlValue) => (decimal)sqlValue;

    public string ToSql(decimal value) => value.ToString(ISqlConverter.InvariantCulture);

    public string ToSql(object value) => ToSql((decimal)value);


    object ISqlConverter.FromSql(object sqlValue) => FromSql((decimal)sqlValue);
}

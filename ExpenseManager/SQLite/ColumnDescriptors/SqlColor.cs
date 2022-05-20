using ExpenseManager.Utilities;

namespace ExpenseManager.SQLite;

public class SqlColor : ISqlColumnDescriptor, ISqlConverter<Color>
{
    public string Name { get; set; }
    public string SqlType => ISqlColumnDescriptor.SqlType_Text;
    public bool NotNull { get; set; }
    public bool Unique { get; set; }
    public bool IsPrimaryKey => false;
    public bool AutoIncrement => false;
    public ISqlConverter Converter => this;

    public Color FromSql(object sqlValue) => HexConverter.HexToRGB((string)sqlValue);

    public string ToSql(Color value) => ISqlConverter.StringToSqlString(HexConverter.RGBToHex(value));

    public SqlColor(string name) {
        Name = name;
    }

    public string ToSql(object value) {
        if (value is Color)
            return ToSql((Color)value);
        throw new ArgumentException($"Not a {typeof(Color).Name}", nameof(value));
    }
    object ISqlConverter.FromSql(object sqlValue) => HexConverter.HexToRGB((string)sqlValue);

    public string ToSqlColumnDefinition() => SqlColumnDescriptorConverter.ToSqlColumnDefinition(this);
}

using System.Globalization;

namespace ExpenseManager.SQLite;

public interface ISqlConverter
{
    private const string quotationMark = "'";
    protected static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
    public object FromSql(object sqlValue);
    public string ToSql(object value);
    protected static string StringToSqlString(object value) => string.Concat(quotationMark, value, quotationMark);
}

public interface ISqlConverter<T> : ISqlConverter
{
    public new T FromSql(object sqlValue);
    public string ToSql(T value);
}

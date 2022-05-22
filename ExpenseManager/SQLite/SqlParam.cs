namespace ExpenseManager.SQLite;

public readonly struct SqlParam
{
    public readonly string Name;
    public readonly object Value;

    public SqlParam(string name, object value) {
        Name = name;
        Value = value;
    }

    public void Deconstruct(out string name, out object value) {
        name = Name;
        value = Value;
    }

    public static implicit operator SqlParam((string, object) tuple) => new(tuple.Item1, tuple.Item2);
    public static implicit operator SQLiteParameter(SqlParam param) {
        var sqlParam = new SQLiteParameter(param.Name) {
            Value = param.Value
        };
        return sqlParam;
    }
}

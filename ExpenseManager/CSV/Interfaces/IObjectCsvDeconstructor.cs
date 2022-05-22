namespace ExpenseManager.CSV;
public interface IObjectCsvDeconstructor<T>
{
    public IReadOnlyList<string> ColumnNames { get; }
    public int FieldCount { get; }

    public string GetFieldAsString(int fieldIndex, T target);

    protected static string ThrowFieldIndexOutOfRange(int fieldCount) => throw new ArgumentOutOfRangeException($"index must be positive and smaller than {fieldCount}");
}

namespace ExpenseManager.SQLite;

public interface IObjectDeconstructor<T>
{
    /// <summary>
    /// Names of columns in database, are in the same order as indexing of GetFieldValueAt
    /// </summary>
    public IReadOnlyList<string> ColumnNames { get; }
    /// <summary>
    /// How many fields does deconstructor supports for extraction
    /// </summary>
    public int FieldCount { get; }

    /// <summary>
    /// Returns value of field/property of target at specified index
    /// </summary>
    /// <param name="index">Value of what field/property to return</param>
    /// <param name="target">Object from which to extract the value</param>
    /// <returns>Value of specified field</returns>
    public object GetFieldValueAt(T target, int index);

    public long GetObjectDatabaseId(T target);

    protected static object? ThrowFieldIndexOutOfRange(int fieldCount) => throw new ArgumentOutOfRangeException($"index must be positive and smaller than {fieldCount}");
}

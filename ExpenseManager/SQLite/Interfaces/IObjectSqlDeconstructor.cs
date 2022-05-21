namespace ExpenseManager.SQLite;

public interface IObjectSqlDeconstructor<T>
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
    /// Returns value of field of target at specified index
    /// </summary>
    /// <param name="index">Value of what field/property to return</param>
    /// <param name="target">Object from which to extract the value</param>
    /// <returns>Value of specified field</returns>
    public object GetFieldValueAt(T target, int index);

    /// <summary>
    /// Returns the value of a field containing the database ID of <see cref="T"/>
    /// </summary>
    /// <param name="target"></param>
    /// <returns>the value of a field containing the database ID of <see cref="T"/></returns>
    public long GetObjectDatabaseId(T target);

    protected static object ThrowFieldIndexOutOfRange(int fieldCount) => throw new ArgumentOutOfRangeException($"index must be positive and smaller than {fieldCount}");
}

namespace ExpenseManager.CSV;
public interface IObjectCsvReconstructor<T>
{
    /// <summary>
    /// How many fields can be set
    /// </summary>
    public int FieldCount { get; }

    /// <summary>
    /// How many fields need to be set for the object to be successfully reconstructed. All fields with indexes in range [0..<see cref="RequiredFieldCount"/> - 1] must be set
    /// </summary>
    public int RequiredFieldCount { get; }

    /// <summary>
    /// Parses the value and sets value of <see cref="T"/>'s field at the specified index to it
    /// </summary>
    /// <param name="fieldIndex">What field to set</param>
    /// <param name="value">Value to be set in the field</param>
    public void SetFieldFromString(int fieldIndex, string value);

    /// <summary>
    /// Creates a <see cref="T"/> from data passed in trough <see cref="SetFieldFromString(int, string)"/>
    /// </summary>
    /// <returns><see cref="T"/> with data set by <see cref="SetFieldFromString(int, string)"/></returns>
    public T ReconstructObject();

    /// <summary>
    /// Resets all field data to their default values, ready to be filled again. Used for reusing the same instance of <see cref="IObjectCsvReconstructor{T}"/>
    /// </summary>
    public void Reset();

    protected static object ThrowFieldIndexOutOfRange(int fieldCount) => throw new ArgumentOutOfRangeException($"index must be positive and smaller than {fieldCount}");
}

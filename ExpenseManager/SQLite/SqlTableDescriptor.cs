namespace ExpenseManager.SQLite;

public class SqlTableDescriptor
{
    private List<ISqlColumnDescriptor> descriptors;
    private List<string> names;

    public ISqlColumnDescriptor PrimaryKey { get; }
    public IReadOnlyList<ISqlColumnDescriptor> Descriptors => descriptors.AsReadOnly();
    public IReadOnlyList<string> Names => names.AsReadOnly();

    public SqlTableDescriptor(params ISqlColumnDescriptor[] columnDescriptors) : this((IEnumerable<ISqlColumnDescriptor>)columnDescriptors) { }

    public SqlTableDescriptor(IEnumerable<ISqlColumnDescriptor> columnDescriptors) {
        ValidateDescriptors(columnDescriptors);
        descriptors = new(columnDescriptors);
        names = descriptors.ConvertAll(c => c.Name);
        PrimaryKey = descriptors.Find(descriptor => descriptor is SqlPrimaryKey) ?? throw new SQLiteException("Table has no primary key defined");
    }

    private static void ValidateDescriptors(IEnumerable<ISqlColumnDescriptor> descriptors) {
        bool hasPrimaryKey = false;
        foreach (var descriptor in descriptors) {
            if (descriptor is SqlPrimaryKey) {
                if (hasPrimaryKey)
                    throw new SQLiteException("Table contains multiple primary keys");
                hasPrimaryKey = true;
            }
        }
    }

    /// <summary>
    /// Returns only column descriptors specified by input names
    /// </summary>
    /// <param name="names"></param>
    /// <exception cref="KeyNotFoundException">Thrown if no column descriptor with spefied name could be found</exception>
    public List<ISqlColumnDescriptor> GetDescriptorsByNames(IEnumerable<string> names) {
        var result = new List<ISqlColumnDescriptor>();
        foreach (var name in names)
            result.Add(descriptors.GetDescriptorByName(name));
        return result;
    }

    public bool ContainsDescriptorWithName(string name) => names.Contains(name);
}

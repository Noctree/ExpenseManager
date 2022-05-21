using ExpenseManager.SQLite;

namespace ExpenseManager.DataObjects.Conversion;
public class CategoryDeconstructor : IObjectSqlDeconstructor<Category>
{
    public IReadOnlyList<string> ColumnNames { get; }
    public int FieldCount => 3;

    public CategoryDeconstructor(IEnumerable<string> columnNames) {
        ColumnNames = columnNames.ToList().AsReadOnly();
    }

    public object GetFieldValueAt(Category target, int index) {
        return index switch {
            0 => target.Name,
            1 => target.Color,
            2 => target.Description,
            _ => IObjectSqlDeconstructor<Category>.ThrowFieldIndexOutOfRange(index),
        };
    }

    public long GetObjectDatabaseId(Category target) => target.Id ?? -1;
}

using ExpenseManager.SQLite;

namespace ExpenseManager.DataObjects.Conversion;
public class TransactionDeconstructor : IObjectDeconstructor<Transaction>
{
    public IReadOnlyList<string> ColumnNames { get; }

    public int FieldCount => 4;

    public TransactionDeconstructor(IEnumerable<string> columnNames) {
        ColumnNames = columnNames.ToList().AsReadOnly();
    }

    public object? GetFieldValueAt(Transaction target, int index) {
        return index switch {
            0 => target.Date,
            1 => target.Amount,
            2 => target.Category.Id ?? throw new NullReferenceException($"Category {target.Category.Name} has no ID"),
            3 => target.Description,
            _ => IObjectDeconstructor<Transaction>.ThrowFieldIndexOutOfRange(index)
        };
    }

    public long GetObjectDatabaseId(Transaction target) => target.Id ?? -1;
}

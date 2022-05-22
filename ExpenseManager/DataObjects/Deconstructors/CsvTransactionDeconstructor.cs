using System.Globalization;
using ExpenseManager.CSV;

namespace ExpenseManager.DataObjects.Conversion;
public class CsvTransactionDeconstructor : IObjectCsvDeconstructor<Transaction>
{
    public IReadOnlyList<string> ColumnNames { get; }

    public int FieldCount => 4;

    public CsvTransactionDeconstructor(IEnumerable<string> columnNames) {
        ColumnNames = columnNames.ToList().AsReadOnly();
    }

    public string GetFieldAsString(int fieldIndex, Transaction target) {
        return fieldIndex switch {
            0 => target.Date.ToString(CultureInfo.InvariantCulture),
            1 => target.Amount.ToString(CultureInfo.InvariantCulture),
            2 => (target.Category.Id ?? 1).ToString(CultureInfo.InvariantCulture),
            3 => target.Description,
            _ => IObjectCsvDeconstructor<Transaction>.ThrowFieldIndexOutOfRange(FieldCount)
        };
    }
}

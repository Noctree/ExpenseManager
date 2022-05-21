using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.CSV;
using ExpenseManager.Utilities;

namespace ExpenseManager.DataObjects.Conversion;
public class CsvCategoryDeconstructor : IObjectCsvDeconstructor<Category>
{
    public IReadOnlyList<string> ColumnNames { get; }

    public int FieldCount => 3;

    public CsvCategoryDeconstructor(IEnumerable<string> columnNames) {
        ColumnNames = columnNames.ToList().AsReadOnly();
    }

    public string GetFieldAsString(int fieldIndex, Category target) {
        return fieldIndex switch {
            0 => target.Name,
            1 => HexConverter.RGBToHex(target.Color),
            2 => target.Description,
            _ => IObjectCsvDeconstructor<Category>.ThrowFieldIndexOutOfRange(FieldCount)
        };
    }
}

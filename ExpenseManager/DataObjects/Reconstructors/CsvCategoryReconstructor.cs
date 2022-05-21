using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.CSV;
using ExpenseManager.Utilities;

namespace ExpenseManager.DataObjects.Conversion;
public class CsvCategoryReconstructor : IObjectCsvReconstructor<Category> {
    private Category category = new Category(Category.Default);
    public int FieldCount => 3;

    public int RequiredFieldCount => 3;

    public Category ReconstructObject() => category;
    public void Reset() {
        category = new Category(Category.Default);
    }
    public void SetFieldFromString(int fieldIndex, string value) {
        switch (fieldIndex) {
            case 0:
                category.Name = value; break;
            case 1:
                category.Color = HexConverter.HexToRGB(value); break;
            case 2:
                category.Description = value; break;
            default:
                IObjectCsvReconstructor<Category>.ThrowFieldIndexOutOfRange(FieldCount);
                break;
        }
    }
}

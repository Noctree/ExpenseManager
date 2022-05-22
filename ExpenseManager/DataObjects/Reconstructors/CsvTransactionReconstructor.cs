using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.CSV;
using System.Globalization;

namespace ExpenseManager.DataObjects.Conversion;
internal class CsvTransactionReconstructor : IObjectCsvReconstructor<Transaction>
{
    private Dictionary<long, Category> categories;
    private Transaction transaction = new Transaction(DateOnly.MinValue, 0, Category.Default);
    public int FieldCount => 4;

    public int RequiredFieldCount => 4;

    public CsvTransactionReconstructor(IEnumerable<Category> categories) {
        this.categories = categories.ToDictionary(category => category.Id ?? throw new ArgumentNullException($"Category {category.Name}has NULL ID"));
    }

    public Transaction ReconstructObject() => transaction;
    public void Reset() => transaction = new Transaction(DateOnly.MinValue, 0, Category.Default);
    public void SetFieldFromString(int fieldIndex, string value) {
        switch (fieldIndex) {
            case 0:
                transaction.Date = DateOnly.Parse(value, CultureInfo.InvariantCulture); break;
            case 1:
                transaction.Amount = decimal.Parse(value, CultureInfo.InvariantCulture); break;
            case 2:
                int index = int.Parse(value, CultureInfo.InvariantCulture);
                if (index < 0 || index >= categories.Count)
                    throw new ArgumentOutOfRangeException("Category ID is invalid");
                transaction.Category = categories[int.Parse(value, CultureInfo.InvariantCulture)]; break;
            case 3:
                transaction.Description = value; break;
            default:
                IObjectCsvReconstructor<Category>.ThrowFieldIndexOutOfRange(FieldCount);
                break;
        }
    }
}

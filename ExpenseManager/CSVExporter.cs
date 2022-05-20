using System.IO;
using ExpenseManager.SQLite;
using System.Text;
using System.Globalization;
using ExpenseManager.Utilities;

namespace ExpenseManager;
public static class CSVExporter {
    private static StringBuilder sb = new StringBuilder();
    public static async Task ExportAsync<T>(string fileName, IObjectDeconstructor<T> deconstructor, IReadOnlyList<T> values) {
        using FileStream fs = File.OpenWrite(fileName);
        using StreamWriter writer = new StreamWriter(fs);
        for (int i = 0; i < deconstructor.FieldCount; i++) {
            await writer.WriteAsync(deconstructor.ColumnNames[i]);
            if (i < deconstructor.FieldCount - 1)
                await writer.WriteAsync(';');
        }
        await writer.WriteLineAsync();
        foreach (var value in values) {
            for (int i = 0; i < deconstructor.FieldCount; i++) {
                await writer.WriteAsync(FormatString(ToString(deconstructor.GetFieldValueAt(value, i))));
                if (i < deconstructor.FieldCount - 1)
                    await writer.WriteAsync(';');
            }
            await writer.WriteLineAsync();
        }
        writer.Close();
    }

    public static async Task ExportExpensesDaoAsync(string fileName, ExpensesDAO dao) {
        await ExportAsync(fileName, dao.TransactionDeconstructor, dao.GetTransactions());
        var categoriesFileName = Path.Combine(Path.GetDirectoryName(fileName) ?? String.Empty, Path.GetFileNameWithoutExtension(fileName) + "-categories.csv");
        await ExportAsync(categoriesFileName, dao.CategoryDeconstructor, dao.GetCategories());
    }

    public static async Task<List<T>> ImportAsync<T>(string fileName, IObjectReconstructor<T> reconstructor) {
        throw new NotImplementedException();
    } 

    private static string ToString(object? obj) {
        return obj switch {
            decimal num => num.ToString(CultureInfo.InvariantCulture),
            double num => num.ToString(CultureInfo.InvariantCulture),
            float num => num.ToString(CultureInfo.InvariantCulture),
            Color color => HexConverter.RGBToHex(color),
            null => string.Empty,
            _ => obj.ToString() ?? string.Empty
        };
    }

    private static string FormatString(string str) {
        sb.Clear();
        for (int i = 0; i < str.Length; ++i) {
            var ch = str[i];
            if (ch >= 32)
                sb.Append(ch);
        }
        return sb.ToString();
    }
}

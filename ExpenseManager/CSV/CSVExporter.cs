using System.IO;

namespace ExpenseManager.CSV;
public static class CsvExporter
{
    private const char Delimiter = ';';
    private static StringBuilder sb = new StringBuilder();
    public static async Task ExportAsync<T>(string fileName, IObjectCsvDeconstructor<T> deconstructor, IEnumerable<T> values) {
        using FileStream fs = File.OpenWrite(fileName);
        using var writer = new StreamWriter(fs);
        for (int i = 0; i < deconstructor.FieldCount; i++) {
            await writer.WriteAsync(deconstructor.ColumnNames[i]);
            if (i < deconstructor.FieldCount - 1)
                await writer.WriteAsync(Delimiter);
        }
        await writer.WriteLineAsync();
        foreach (var value in values) {
            for (int i = 0; i < deconstructor.FieldCount; i++) {
                await writer.WriteAsync(FormatString(deconstructor.GetFieldAsString(i, value)));
                if (i < deconstructor.FieldCount - 1)
                    await writer.WriteAsync(Delimiter);
            }
            await writer.WriteLineAsync();
        }
        writer.Close();
    }

    public static async Task<List<T>> ImportAsync<T>(string fileName, IObjectCsvReconstructor<T> reconstructor) {
        var results = new List<T>();
        using FileStream fs = File.OpenRead(fileName);
        using var reader = new StreamReader(fs);
        await reader.ReadLineAsync();  //Skip header

        int lineCounter = 0;
        while (!reader.EndOfStream) {
            ++lineCounter;
            string? line = await reader.ReadLineAsync();
            if (line is null)
                break;
            var chunks = line.Split(Delimiter);
            if (chunks.Length < reconstructor.RequiredFieldCount)
                throw new FormatException($"Data on line {lineCounter} does not contain enough data to reconstruct {typeof(T).Name}");
            reconstructor.Reset();
            for (int i = 0; i < chunks.Length && i < reconstructor.FieldCount; ++i)
                reconstructor.SetFieldFromString(i, chunks[i]);
            results.Add(reconstructor.ReconstructObject());
        }
        reader.Close();
        return results;
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

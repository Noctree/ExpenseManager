using ExpenseManager.DataObjects;

namespace ExpenseManager;

internal static class DataGenerator
{
    private static readonly Random rng = new();

    private static char GenerateLetter() => rng.NextDouble() < 0.5 ? (char)rng.Next('a', 'z' + 1) : (char)rng.Next('A', 'Z' + 1);

    private static string GenerateString(int length) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++) {
            sb.Append(GenerateLetter());
        }
        return sb.ToString();
    }

    private static Color GenerateColor() => Color.FromArgb(255, rng.Next(256), rng.Next(256), rng.Next(256));

    private static decimal GenerateAmount(int min, int max) => new(rng.Next(min * 100, max * 100) / 100d);
    private static DateOnly GenerateDate(DateOnly? max = null) => DateOnly.FromDayNumber(rng.Next(max is null ? DateOnly.FromDateTime(DateTime.UtcNow).DayNumber : max.Value.DayNumber));

    public static Category GenerateCategory() => new(GenerateString(10), GenerateColor(), GenerateString(25));

    public static Transaction GenerateTransaction(Category category) => new(GenerateDate(), GenerateAmount(-50_000, 50_000), category, GenerateString(25));

    public static void GenerateDatabase(ExpensesDAO dao, int categoryCount, int transactionCount) {
        var categories = new List<Category>();
        var transactions = new List<Transaction>();
        for (int i = 0; i < categoryCount; i++)
            categories.Add(GenerateCategory());
        Console.WriteLine("Add generated categories - " + dao.AddCategories(categories, out var _));
        categories.Clear();
        categories = dao.GetCategories();

        for (int i = 0; i < transactionCount; i++)
            transactions.Add(GenerateTransaction(categories[i * 53 % categoryCount]));
        Console.WriteLine($"Add generated transactions - " + dao.AddTransactions(transactions, out var _));
    }
}

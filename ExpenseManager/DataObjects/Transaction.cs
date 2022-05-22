namespace ExpenseManager.DataObjects;

public class Transaction
{
    public long? Id { get; private set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public Transaction(DateOnly date, decimal amount, Category? category, string? description = null, long? id = null) {
        Id = id;
        Date = date;
        Amount = amount;
        Category = category ?? Category.Default;
        Description = description ?? string.Empty;
    }

    public Transaction(Transaction transaction, long? id = null) {
        Id = id;
        Date = transaction.Date;
        Amount = transaction.Amount;
        Category = transaction.Category;
        Description = transaction.Description;
    }

    public void Invalidate() => Id = null;

    public override string ToString() => $"{Date} | {Amount} | {Category.Name} | {Description}";

    public override bool Equals(object? obj) => obj is Transaction transaction && Id == transaction.Id;
    public override int GetHashCode() => HashCode.Combine(Id);

    /// <summary>
    /// Compares all fields instead of just IDs
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>True if all fields match</returns>
    public static bool AreEqual(Transaction a, Transaction b) {
        return a.Id == b.Id &&
            a.Date == b.Date &&
            a.Amount == b.Amount &&
            Category.AreEqual(a.Category, b.Category) &&
            a.Description.Equals(b.Description);
    }
    public static bool operator ==(Transaction? left, Transaction? right) => EqualityComparer<Transaction>.Default.Equals(left, right);
    public static bool operator !=(Transaction? left, Transaction? right) => !(left == right);
}

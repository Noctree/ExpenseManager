namespace ExpenseManager.DataObjects;

public class Category
{
    private static readonly Color DEFAULT_COLOR = Color.White;
    public static Category Default { get; } = new Category(string.Empty, id: 1);
    public long? Id { get; private set; }
    public string Name { get; set; }
    public Color Color { get; set; }
    public string Description { get; set; }

    public Category(string name, Color? color = null, string? description = null, long? id = null) {
        Id = id;
        Name = name;
        Description = description ?? string.Empty;
        Color = color ?? DEFAULT_COLOR;
    }

    public Category(Category category, long? id = null) {
        Id = id;
        Name = category.Name;
        Description = category.Description;
        Color = category.Color;
    }

    public void Invalidate() => Id = -1;

    public override string ToString() => $"{Name} | {Description} | {Color}";

    public override bool Equals(object? obj) => obj is Category category && Id == category.Id;
    public override int GetHashCode() => HashCode.Combine(Id);

    /// <summary>
    /// Compares all fields instead of just IDs
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>True if all fields match</returns>
    public static bool AreEqual(Category a, Category b) {
        return a.Id == b.Id &&
            a.Name.Equals(b.Name) &&
            a.Color.Equals(b.Color) &&
            a.Description.Equals(b.Description);
    }

    public static bool operator ==(Category? left, Category? right) => EqualityComparer<Category>.Default.Equals(left, right);
    public static bool operator !=(Category? left, Category? right) => !(left == right);
}

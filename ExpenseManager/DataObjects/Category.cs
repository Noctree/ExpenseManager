namespace ExpenseManager.DataObjects;

public class Category
{
    private static readonly Color DEFAULT_COLOR = Color.White;
    public static Category Default { get; } = new Category(string.Empty);
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

    public override string ToString() {
        return $"{Name} | {Description} | {Color}";
    }

    public override bool Equals(object? obj) => obj is Category category && Id == category.Id;
    public override int GetHashCode() => HashCode.Combine(Id);

    public static bool operator ==(Category? left, Category? right) => EqualityComparer<Category>.Default.Equals(left, right);
    public static bool operator !=(Category? left, Category? right) => !(left == right);
}

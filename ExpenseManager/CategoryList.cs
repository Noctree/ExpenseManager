using ExpenseManager.DataObjects;

namespace ExpenseManager;
public class CategoryList : List<Category>
{
    public CategoryList() { }

    public CategoryList(IEnumerable<Category> categories) {
        AddRange(categories);
    }

    public Category GetByIndex(int index) => base[index];
    public Category? GetById(long id) => Find(category => category.Id == id);
    public bool ContainsCategoryWithId(long id) => this.Any(category => category.Id == id);
}

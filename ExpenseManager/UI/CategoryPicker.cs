using ExpenseManager.DataObjects;

namespace ExpenseManager.UI;
public partial class CategoryPicker : Form
{
    private Dictionary<int, Category> categories;
    public int SelectedCategoryIndex { get; set; } = 0;
    public Category SelectedCategory => categories[SelectedCategoryIndex == -1? 0 : SelectedCategoryIndex];
    public CategoryPicker() {
        InitializeComponent();
    }

    public DialogResult ShowDialog(List<Category> categories) {
        this.categories = new();
        for (int i = 0; i < categories.Count; ++i)
            this.categories.Add(i, categories[i]);
        CategoryComboBox.Items.Clear();
        CategoryComboBox.Items.AddRange(categories.Select(c => c.Name).ToArray());
        CategoryComboBox.SelectedIndex = SelectedCategoryIndex < categories.Count ? SelectedCategoryIndex : categories.Count - 1;
        return base.ShowDialog();
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        SelectedCategoryIndex = CategoryComboBox.SelectedIndex;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

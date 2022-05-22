using ExpenseManager.DataObjects;
using ExpenseManager.UI.Components;

namespace ExpenseManager.UI;

public partial class CategoriesView : Form
{
    private ExpensesDAO dao;
    private CategoryEditor editor;
    public event Action? CategoriesModified;
    public CategoriesView() {
        InitializeComponent();
        Disposed += CleanUp;
        CategoryDataGridView.SelectionChanged += CategoryDataGridView_SelectionChanged;
    }

    public new void Show() => throw new NotSupportedException($"{nameof(ExpensesDAO)} must be passed as an argument");

    public void Show(ExpensesDAO dao) {
        this.dao = dao;
        CategoryDataGridView.Initialize(dao);
        UpdateControls();
        base.Show();
    }

    private void CloseFormButton_Click(object sender, EventArgs e) {
        CategoryDataGridView.Reset();
        Hide();
    }
    private void CleanUp(object? sender, EventArgs e) {
        CategoryDataGridView.DataSource = null;
        CategoryDataGridView.Rows.Clear();
        CategoryDataGridView.Dispose();
        editor?.Dispose();
    }

    private void UpdateControls() {
        EditSelectedButton.Enabled = CategoryDataGridView.SelectedRows.Count == 1;
        DeleteSelectedButton.Enabled = CategoryDataGridView.SelectedRows.Count > 0;
        CloneSelectedButton.Enabled = CategoryDataGridView.SelectedRows.Count == 1;
    }

    private void EditSelectedButton_Click(object sender, EventArgs e) {
        var category = (Category)CategoryDataGridView.SelectedRows[0].Cells[0].Value;
        if (editor is null)
            editor = new CategoryEditor(dao);
        if (editor.ShowDialog(category) == DialogResult.OK) {
            if (dao.UpdateCategory(category)) {
                CategoryDataGridView.Refresh();
                CategoriesModified?.Invoke();
            }
            else {
                MessageBox.Show("Failed to modify category", "Error", MessageBoxButtons.OK);
            }
        }
    }
    private void CategoryDataGridView_SelectionChanged(object? sender, EventArgs e) => UpdateControls();

    private void AddSelectedButton_Click(object sender, EventArgs e) {
        var category = new Category(Category.Default);
        if (editor is null)
            editor = new CategoryEditor(dao);
        if (editor.ShowDialog(category) == DialogResult.OK) {
            if (dao.AddCategory(category, out var addedCategory)) {
                CategoryDataGridView.AddRow(addedCategory!);
                CategoryDataGridView.Refresh();
            }
            else {
                MessageBox.Show("Failed to add category", "Error", MessageBoxButtons.OK);
            }
        }
    }

    private void DeleteSelectedButton_Click(object sender, EventArgs e) {
        if (MessageBox.Show("Delete selected categories?", "Are you sure?", MessageBoxButtons.OKCancel) != DialogResult.OK)
            return;

        var categories = new List<Category>();
        var rows = CategoryDataGridView.SelectedRows;
        for (int i = 0; i < rows.Count; i++)
            categories.Add((Category)rows[i].Cells[0].Value);
        CategoryDataGridView.RemoveRows(categories);
        dao.DeleteCategories(categories);
        CategoriesModified?.Invoke();
    }

    private void CloneSelectedButton_Click(object sender, EventArgs e) {
        var categories = new List<Category>();
        var rows = CategoryDataGridView.SelectedRows;
        for (int i = 0; i < rows.Count; i++)
            categories.Add((Category)rows[i].Cells[0].Value);
        dao.AddCategories(categories, out var addedCategories);
        CategoryDataGridView.AddRows(addedCategories);
    }
}

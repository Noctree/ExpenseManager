using ExpenseManager.DataObjects;

namespace ExpenseManager.UI;
public partial class CategoryEditor : Form
{
    private readonly ExpensesDAO expensesDAO;
    private Category category;
    public CategoryEditor(ExpensesDAO dao) {
        expensesDAO = dao;
        InitializeComponent();
    }

    public new DialogResult ShowDialog() => throw new NotSupportedException($"{nameof(CategoryEditor)} only supports ShowDialog with provided {nameof(Category)}");
    public DialogResult ShowDialog(Category category) {
        this.category = category;
        LoadCategory(category);
        return base.ShowDialog();
    }

    private void LoadCategory(Category category) {
        NameField.Text = category.Name;
        ColorField.SelectedColor = category.Color;
        DescriptionField.Text = category.Description;
    }

    private void ModifyCategory(Category category) {
        category.Name = NameField.Text;
        category.Color = ColorField.SelectedColor;
        category.Description = DescriptionField.Text;
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        ModifyCategory(category);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

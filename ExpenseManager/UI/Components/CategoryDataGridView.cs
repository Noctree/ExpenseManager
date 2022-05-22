using ExpenseManager.DataObjects;

namespace ExpenseManager.UI.Components;

public class CategoryDataGridView : DataGridClassView<Category>
{
    private static readonly DataGridViewTextBoxCell DefaultCellTemplate = new();
    private ExpensesDAO? expensesDAO;
    public ExpensesDAO ExpensesDAO => expensesDAO is null ? throw new ApplicationException("DataView not initialized") : expensesDAO;
    public bool Initialized { get; private set; }

    public CategoryDataGridView() {
        AutoGenerateColumns = false;
    }

    private void InitializeColumns() {
        Columns[0].CellTemplate = new DataGridViewGenericTextBoxCell<Category>() {
            TextFormatter = (category) => category.Name
        };
        Columns[1].CellTemplate = new DataGridViewCategoryColorCell();
        Columns[2].CellTemplate = new DataGridViewGenericTextBoxCell<Category>() {
            TextFormatter = (category) => category.Description
        };
    }

    public void Initialize(ExpensesDAO dao) {
        if (Initialized)
            return;
        ShowCellToolTips = false;
        InitializeColumns();
        expensesDAO = dao;
        var categories = dao.GetCategories();
        categories.Remove(dao.DefaultCategory);
        if (categories.Count > 0) {
            AddRows(categories);
        }
        Initialized = true;
    }

    public void Reset() {
        Initialized = false;
        ClearRows();
    }
}

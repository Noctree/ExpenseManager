using ExpenseManager.DataObjects;

namespace ExpenseManager.UI;

public class CategoryDataGridView : DataGridView
{
    private static readonly DataGridViewTextBoxCell DefaultCellTemplate = new();
    private ExpensesDAO? expensesDAO;
    public ExpensesDAO ExpensesDAO {
        get {
            if (expensesDAO is null)
                throw new ApplicationException("DataView not initialized");
            return expensesDAO;
        }
    }
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
        Rows.Add(categories.Count);
        for (int i = 0; i < Rows.Count; i++) {
            var cells = Rows[i].Cells;
            for (int j = 0; j < cells.Count; j++)
                cells[j].Value = categories[i];
        }
        Initialized = true;
    }

    public void Reset() {
        Initialized = false;
        Rows.Clear();
    }

    public void AddCategory(Category category) {
        var objects = new object[Rows.Count];
        for (int i = 0; i < objects.Length; ++i)
            objects[i] = category;
        Rows.Add(objects);
    }

    public void AddCategories(IList<Category> categories) {
        var objects = new object[Rows.Count];
        foreach (var category in categories) {
            for (int i = 0; i < objects.Length; ++i)
                objects[i] = category;
            Rows.Add(objects);
        }
    }

    public void RemoveCategory(Category category) {
        for (int i = 0; i < Rows.Count; ++i)
            if (((Category)Rows[i].Cells[0].Value) == category)
                Rows.RemoveAt(i);
    }

    public void RemoveCategories(IList<Category> transactions) {
        var transactionDict = transactions.ToDictionary(transaction => transaction.Id ?? -1);
        var toBeRemoved = new List<int>();
        for (int i = 0; i < Rows.Count; ++i) {
            if (transactionDict.ContainsKey(((Category)Rows[i].Cells[0].Value).Id ?? -1))
                toBeRemoved.Add(i);
        }
        SuspendLayout();
        toBeRemoved.Sort();
        foreach (var index in (toBeRemoved as IEnumerable<int>).Reverse())
            Rows.RemoveAt(index);
        ResumeLayout(true);
    }

    protected override void OnColumnAdded(DataGridViewColumnEventArgs e) {
        e.Column.CellTemplate = DefaultCellTemplate;
        base.OnColumnAdded(e);
    }

    protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e) {
        if (e.ColumnIndex == 0) {
            var direction = Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
            direction = (SortOrder)(((int)direction + 1) % 3);
            if (direction != SortOrder.None)
                Sort(Columns[e.ColumnIndex], direction == SortOrder.Ascending ? System.ComponentModel.ListSortDirection.Ascending : System.ComponentModel.ListSortDirection.Descending);
            Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direction;
        }
        base.OnColumnHeaderMouseClick(e);
    }

    protected override void OnSortCompare(DataGridViewSortCompareEventArgs e) {
        e.Handled = true;
        e.SortResult = string.Compare((e.CellValue1 as Category)?.Name, (e.CellValue2 as Category)?.Name, StringComparison.InvariantCulture);
    }
}

using ExpenseManager.DataObjects;

namespace ExpenseManager.UI;

public class TransactionsDataGridView : DataGridView
{
    private static readonly DataGridViewTextBoxCell DefaultCellTemplate = new();

    private ExpensesDAO? expensesDAO;
    private List<Transaction>? transactions;
    public ExpensesDAO ExpensesDAO {
        get {
            if (expensesDAO is null)
                throw new ApplicationException("DataView not initialized");
            return expensesDAO;
        }
    }
    public bool Initialized { get; private set; }

    private void InitializeColumns() {
        Columns[0].CellTemplate = new DataGridViewGenericTextBoxCell<Transaction>() {
            TextFormatter = transaction => transaction.Date.ToString()
        };
        Columns[1].CellTemplate = new DataGridViewTransactionAmountCell() {
            TextFormatter = transaction => transaction.Amount.ToString()
        };
        Columns[2].CellTemplate = new DataGridViewCategoryCell();
        Columns[3].CellTemplate = new DataGridViewGenericTextBoxCell<Transaction>() {
            TextFormatter = transaction => transaction.Description
        };
    }

    public async Task PreloadTransactionsAsync(ExpensesDAO dao) {
        expensesDAO = dao;
        transactions = await expensesDAO.GetTransactionsAsync();
    }

    public void Initialize(ExpensesDAO dao) {
        if (Initialized)
            return;
        ShowCellToolTips = false;
        InitializeColumns();
        expensesDAO = dao;
        if (transactions is null)
            transactions = dao.GetTransactions();
        Rows.Add(transactions.Count);
        for (int i = 0; i < Rows.Count; ++i) {
            var cells = Rows[i].Cells;
            for (int j = 0; j < cells.Count; ++j)
                cells[j].Value = j == 2 ? transactions[i].Category : transactions[i];
        }
        Disposed += CleanUp;
        Initialized = true;
    }

    public void AddTransaction(Transaction transaction) {
        var objects = new object[Rows.Count];
        for (int i = 0; i < objects.Length; ++i)
            objects[i] = i == 2? transaction.Category : transaction;
        Rows.Add(objects);
    }

    public void AddTransactions(IList<Transaction> transactions) {
        var objects = new object[Rows.Count];
        foreach (var transaction in transactions) {
            for (int i = 0; i < objects.Length; ++i)
                objects[i] = i == 2 ? transaction.Category : transaction;
            Rows.Add(objects);
        }
    }

    public void RemoveTransaction(Transaction transaction) {
        for (int i = 0; i < Rows.Count; ++i)
            if (((Transaction)Rows[i].Cells[0].Value) == transaction)
                Rows.RemoveAt(i);
    }

    public void RemoveTransactions(IList<Transaction> transactions) {
        var transactionDict = transactions.ToDictionary(transaction => transaction.Id ?? -1);
        var toBeRemoved = new List<int>();
        for (int i = 0; i < Rows.Count; ++i) {
            if (transactionDict.ContainsKey(((Transaction)Rows[i].Cells[0].Value).Id ?? -1))
                toBeRemoved.Add(i);
        }
        SuspendLayout();
        toBeRemoved.Sort();
        foreach (var index in (toBeRemoved as IEnumerable<int>).Reverse())
            Rows.RemoveAt(index);
        ResumeLayout(true);
    }

    public void FilterRows(Predicate<Transaction> predicate) {
        for (int i = 0; i < Rows.Count; ++i) {
            Rows[i].Visible = predicate((Transaction)Rows[i].Cells[0].Value);
        }
    }

    public void ClearFilter() {
        for (int i = 0; i < Rows.Count; ++i)
            Rows[i].Visible = true;
    }

    private void CleanUp(object? sender, EventArgs e) => transactions?.Clear();

    protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e) {
        if (e.ColumnIndex < 2) {
            for (int i = 0; i < 2; ++i)
                if (i != e.ColumnIndex)
                    Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
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
        switch (e.Column.Index) {
            case 0:
                e.SortResult = SortByDate(e);
                return;
            case 1:
                e.SortResult = SortByAmount(e);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(e.Column.Index));
        }
    }

    private static int SortByDate(DataGridViewSortCompareEventArgs e) => ((Transaction)e.CellValue1).Date.CompareTo(((Transaction)e.CellValue2).Date);
    private static int SortByAmount(DataGridViewSortCompareEventArgs e) => ((Transaction)e.CellValue1).Amount.CompareTo(((Transaction)e.CellValue2).Amount);
}

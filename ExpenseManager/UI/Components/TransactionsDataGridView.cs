using ExpenseManager.DataObjects;

namespace ExpenseManager.UI.Components;

public class TransactionsDataGridView : DataGridClassView<Transaction>
{
    private static readonly DataGridViewTextBoxCell DefaultCellTemplate = new();

    private ExpensesDAO? expensesDAO;
    private List<Transaction>? transactions;
    public ExpensesDAO ExpensesDAO => expensesDAO is null ? throw new ApplicationException("DataView not initialized") : expensesDAO;
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
        RegisterColumnSorters();
        RegisterColumnValueSelectors();

        expensesDAO = dao;
        if (transactions is null)
            transactions = dao.GetTransactions();
        if (transactions.Count > 0) {
            AddRows(transactions);
        }
        transactions.Clear();
        transactions = null;
        Initialized = true;
    }

    private void RegisterColumnSorters() {
        RegisterColumnSortComparer(0, (a, b) => a.Date.CompareTo(b.Date));
        RegisterColumnSortComparer(1, (a, b) => a.Amount.CompareTo(b.Amount));
    }

    private void RegisterColumnValueSelectors() => RegisterColumnValueSelector(2, transaction => transaction.Category);
}

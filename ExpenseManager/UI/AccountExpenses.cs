using ExpenseManager.DataObjects;
using ExpenseManager.UI.Components;

namespace ExpenseManager.UI;

public partial class AccountExpenses : UserControl {
    private Panel? overlay;
    private CategoriesView? categoriesView;
    private TransactionEditor? transactionEditor;
    private ExpensesDAO expensesDAO;
    private DateRangePicker datePicker = new DateRangePicker();
    private AmountPicker amountPicker = new AmountPicker();
    private CategoryPicker categoryPicker = new CategoryPicker();

    public ExpensesDAO DAO => expensesDAO;
    public event Action<AccountExpenses> RequestsClose;
    public AccountExpenses(ExpensesDAO dao) {
        this.expensesDAO = dao;
        InitializeComponent();
        TransactionsDataGridView.SelectionChanged += TransactionsDataGridView_SelectionChanged;
        Disposed += CleanUp;
    }

    public async Task PreloadDataAsync() => await TransactionsDataGridView.PreloadTransactionsAsync(expensesDAO);

    private void CreateLoadingOverlay() {
        overlay = new Panel();
        overlay.Dock = DockStyle.Fill;
        overlay.BackColor = SystemColors.Control;
        var label = new Label();
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Text = "Loading...";
        label.ForeColor = SystemColors.ControlDark;
        var font = new Font(label.Font.FontFamily, 36);
        label.Font = font;
        this.Controls.Add(overlay);
        overlay.Controls.Add(label);
        label.Size = label.Parent.Size;
        label.Location = new Point(0, 0);
        overlay.Visible = false;
    }

    private void EnableLoadingOverlay() {
        if (overlay is null)
            CreateLoadingOverlay();
        overlay!.Visible = true;
        overlay.BringToFront();
        Refresh();
        Application.DoEvents();
    }

    private void DisableLoadingOverlay() {
        if (overlay is not null) {
            overlay.Visible = false;
            Refresh();
        }
    }

    protected override void OnLoad(EventArgs e) {
        Initialize();
        ComputeTotalBallance();
        FilteredBallanceDisplay.Text = TotalBallanceDisplay.Text;
        base.OnLoad(e);
    }

    private void Initialize() {
        Console.WriteLine(Name + " Loaded");
        EnableLoadingOverlay();
        TransactionsDataGridView.Initialize(expensesDAO);
        DisableLoadingOverlay();
        UpdateControlButtons();
        TransactionsDataGridView.ClearSelection();
        TransactionsDataGridView.OnRowsFiltered += ComputeFilteredBallance;
    }

    private void ComputeTotalBallance() {
        TotalBallanceDisplay.Text = TransactionsDataGridView.GetRowValues().Sum(transaction => transaction.Amount).ToString(System.Globalization.CultureInfo.InvariantCulture) + " Kč";
    }

    private void ComputeFilteredBallance() {
        FilteredBallanceDisplay.Text = TransactionsDataGridView.GetFilteredRowValues().Sum(transaction => transaction.Amount).ToString(System.Globalization.CultureInfo.InvariantCulture) + " Kč";
    }

    private void OpenCategoriesPanel_Click(object sender, EventArgs e) {
        if (categoriesView is null) {
            categoriesView = new CategoriesView();
            categoriesView.CategoriesModified += OnCategoriesModified;
        }
        categoriesView.Show(expensesDAO);
    }

    private void OnCategoriesModified() => TransactionsDataGridView.Refresh();

    private void CleanUp(object? sender, EventArgs e) {
        TransactionsDataGridView.Dispose();
        categoriesView?.Dispose();
        transactionEditor?.Dispose();
        foreach (var child in Controls)
            (child as Control)?.Dispose();
    }

    private void CloseDatabaseButton_Click(object sender, EventArgs e) {
        RequestsClose?.Invoke(this);
    }

    private void TransactionsDataGridView_SelectionChanged(object? sender, EventArgs e) => UpdateControlButtons();

    private void UpdateControlButtons() {
        EditTransactionButton.Enabled = TransactionsDataGridView.SelectedRows.Count == 1;
        DeleteTransactionButton.Enabled = TransactionsDataGridView.SelectedRows.Count > 0;
        CloneTransactionButton.Enabled = TransactionsDataGridView.SelectedRows.Count > 0;
    }

    private void EditTransactionButton_Click(object sender, EventArgs e) {
        var transaction = (Transaction)TransactionsDataGridView.SelectedRows[0].Cells[0].Value;
        if (transactionEditor is null)
            transactionEditor = new TransactionEditor(expensesDAO);
        if (transactionEditor.ShowDialog(transaction) == DialogResult.OK) {
            if (DAO.UpdateTransaction(transaction))
                TransactionsDataGridView.Refresh();
            else
                MessageBox.Show("Failed to modify transaction", "Error", MessageBoxButtons.OK);
        }
    }

    private void NewTransactionButton_Click(object sender, EventArgs e) {
        var transaction = new Transaction(DateOnly.FromDateTime(DateTime.Today), 0, DAO.DefaultCategory);
        if (transactionEditor is null)
            transactionEditor = new TransactionEditor(expensesDAO);
        if (transactionEditor.ShowDialog(transaction) == DialogResult.OK) {
            if (expensesDAO.AddTransaction(transaction, out var addedTransaction)) {
                TransactionsDataGridView.AddTransaction(addedTransaction!);
                TransactionsDataGridView.Refresh();
            }
            else
                MessageBox.Show("Failed to add transaction", "Error", MessageBoxButtons.OK);
        }
    }

    private void DeleteTransactionButton_Click(object sender, EventArgs e) {
        if (MessageBox.Show("Delete selected transactions?", "Are you sure?", MessageBoxButtons.OKCancel) != DialogResult.OK)
            return;

        var transactions = new List<Transaction>();
        var rows = TransactionsDataGridView.SelectedRows;
        for (int i = 0; i < rows.Count; ++i)
            transactions.Add((Transaction)rows[i].Cells[0].Value);
        TransactionsDataGridView.RemoveTransactions(transactions);
        if (!DAO.DeleteTransactions(transactions))
            MessageBox.Show("Failed to delete selected rows,\nplease close this account and reopen it", "Error", MessageBoxButtons.OK);
    }

    private void CloneTransactionButton_Click(object sender, EventArgs e) {
        var transactions = new List<Transaction>();
        var rows = TransactionsDataGridView.SelectedRows;
        for (int i = 0; i < rows.Count; ++i)
            transactions.Add((Transaction)rows[i].Cells[0].Value);
        DAO.AddTransactions(transactions, out var addedTransactions);
        TransactionsDataGridView.AddTransactions(addedTransactions);
    }

    private void ClearFilters_Click(object sender, EventArgs e) {
        TransactionsDataGridView.ClearFilter();
    }

    private void FilterByDateButton_Click(object sender, EventArgs e) {
        if (datePicker.ShowDialog() == DialogResult.OK) {
            TransactionsDataGridView.FilterRows(transaction => datePicker.From <= transaction.Date && transaction.Date <= datePicker.To);
        }
    }

    private void FilterByAmountButton_Click(object sender, EventArgs e) {
        if (amountPicker.ShowDialog() == DialogResult.OK)
            TransactionsDataGridView.FilterRows(transaction => amountPicker.From <= transaction.Amount && transaction.Amount <= amountPicker.To);
    }

    private void FilterByCategoryButton_Click(object sender, EventArgs e) {
        if (categoryPicker.ShowDialog(DAO.GetCategories()) == DialogResult.OK)
            TransactionsDataGridView.FilterRows(transaction => transaction.Category == categoryPicker.SelectedCategory);
    }
}

using System.Globalization;
using ExpenseManager.DataObjects;
using ExpenseManager.UI.Components;

namespace ExpenseManager.UI;

public partial class AccountExpenses : UserControl
{
    private Panel? overlay;
    private CategoriesView? categoriesView;
    private TransactionEditor? transactionEditor;
    private readonly DateRangePicker datePicker = new();
    private readonly AmountPicker amountPicker = new();
    private readonly CategoryPicker categoryPicker = new();

    private readonly NumberFormatInfo numberFormatInfo;

    public ExpensesDAO DAO { get; }
    public event Action<AccountExpenses>? RequestsClose;
    public AccountExpenses(ExpensesDAO dao) {
        this.DAO = dao;
        InitializeComponent();
        TransactionsDataGridView.SelectionChanged += TransactionsDataGridView_SelectionChanged;
        Disposed += CleanUp;

        numberFormatInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        numberFormatInfo.CurrencyDecimalDigits = 2;
        numberFormatInfo.NumberDecimalDigits = 2;
        TotalBallanceCurrencyDisplay.Text = numberFormatInfo.CurrencySymbol;
        FilteredBallanceCurrencyDisplay.Text = numberFormatInfo.CurrencySymbol;
    }

    public async Task PreloadDataAsync() => await TransactionsDataGridView.PreloadTransactionsAsync(DAO);

    private void CreateLoadingOverlay() {
        overlay = new Panel {
            Dock = DockStyle.Fill,
            BackColor = SystemColors.Control
        };
        var label = new Label {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Loading...",
            ForeColor = SystemColors.ControlDark
        };
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
        TransactionsDataGridView.Initialize(DAO);
        DisableLoadingOverlay();
        UpdateControlButtons();
        TransactionsDataGridView.ClearSelection();
        TransactionsDataGridView.OnRowsFiltered += TransactionsDataGridView_OnRowsFiltered;
    }

    private void TransactionsDataGridView_OnRowsFiltered(object? sender, EventArgs e) => ComputeFilteredBallance();

    private void ComputeTotalBallance() => TotalBallanceDisplay.Text = TransactionsDataGridView.Values.Sum(transaction => transaction.Amount).ToString("n", numberFormatInfo);

    private void ComputeFilteredBallance() => FilteredBallanceDisplay.Text = TransactionsDataGridView.GetVisibleValues().Sum(transaction => transaction.Amount).ToString("n", numberFormatInfo);

    private void OpenCategoriesPanel_Click(object sender, EventArgs e) {
        if (categoriesView is null) {
            categoriesView = new CategoriesView();
            categoriesView.CategoriesModified += OnCategoriesModified;
        }
        categoriesView.Show(DAO);
    }

    private void OnCategoriesModified() => TransactionsDataGridView.Refresh();

    private void CleanUp(object? sender, EventArgs e) {
        TransactionsDataGridView.Dispose();
        categoriesView?.Dispose();
        transactionEditor?.Dispose();
        foreach (var child in Controls)
            (child as Control)?.Dispose();
    }

    private void CloseDatabaseButton_Click(object sender, EventArgs e) => RequestsClose?.Invoke(this);

    private void TransactionsDataGridView_SelectionChanged(object? sender, EventArgs e) => UpdateControlButtons();

    private void UpdateControlButtons() {
        EditTransactionButton.Enabled = TransactionsDataGridView.SelectedRows.Count == 1;
        DeleteTransactionButton.Enabled = TransactionsDataGridView.SelectedRows.Count > 0;
        CloneTransactionButton.Enabled = TransactionsDataGridView.SelectedRows.Count > 0;
    }

    private void EditTransactionButton_Click(object sender, EventArgs e) {
        var selectedRow = TransactionsDataGridView.SelectedRows[0];
        var transaction = (Transaction)selectedRow.Cells[0].Value;
        if (transactionEditor is null)
            transactionEditor = new TransactionEditor(DAO);
        var oldTransactionId = transaction.Category.Id;
        if (transactionEditor.ShowDialog(transaction) == DialogResult.OK) {
            if (DAO.UpdateTransaction(transaction)) {
                if (transaction.Category.Id != oldTransactionId) {
                    selectedRow.Cells[2].Value = transaction.Category;
                }
                TransactionsDataGridView.Refresh();
            }
            else {
                MessageBoxUtils.ShowError("Failed to modify transaction");
            }
        }
    }

    private void NewTransactionButton_Click(object sender, EventArgs e) {
        var transaction = new Transaction(DateOnly.FromDateTime(DateTime.Today), 0, DAO.DefaultCategory);
        if (transactionEditor is null)
            transactionEditor = new TransactionEditor(DAO);
        if (transactionEditor.ShowDialog(transaction) == DialogResult.OK) {
            if (DAO.AddTransaction(transaction, out var addedTransaction)) {
                TransactionsDataGridView.AddRow(addedTransaction!);
                TransactionsDataGridView.Refresh();
            }
            else {
                MessageBoxUtils.ShowError("Failed to add transaction");
            }
        }
    }

    private void DeleteTransactionButton_Click(object sender, EventArgs e) {
        if (!MessageBoxUtils.ShowConfirmation("Delete selected transactions?", true))
            return;

        var transactions = new List<Transaction>();
        var rows = TransactionsDataGridView.SelectedRows;
        for (int i = 0; i < rows.Count; ++i)
            transactions.Add((Transaction)rows[i].Cells[0].Value);
        TransactionsDataGridView.RemoveRows(transactions);
        if (!DAO.DeleteTransactions(transactions))
            MessageBoxUtils.ShowError("Failed to delete selected rows,\nplease close this account and reopen it to continue working on it");
    }

    private void CloneTransactionButton_Click(object sender, EventArgs e) {
        var transactions = new List<Transaction>();
        var rows = TransactionsDataGridView.SelectedRows;
        for (int i = 0; i < rows.Count; ++i)
            transactions.Add((Transaction)rows[i].Cells[0].Value);
        DAO.AddTransactions(transactions, out var addedTransactions);
        TransactionsDataGridView.AddRows(addedTransactions);
    }

    private void ClearFilters_Click(object sender, EventArgs e) => TransactionsDataGridView.ClearFilter();

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

using ExpenseManager.UI.Components;
using ExpenseManager.Utilities;

namespace ExpenseManager.UI;

public partial class MainForm : Form
{
    private const string DatabaseDirectory = "Data/";
    private bool close;
    private OpenDatabaseDialog openDatabaseDialog;
    private DatabaseManager databaseManager;
    private ImportAccountDialog importAccountDialog;
    private readonly Dictionary<string, (AccountExpenses, int)> openDatabases = new();
    public bool BackendInitialized { get; private set; }
    public MainForm() {
        InitializeComponent();
        FormClosing += OnFormClosing;
    }

    private void OnFormClosing(object? sender, FormClosingEventArgs e) => databaseManager.CloseAllUsers();

    private void OnUIInitialized(object sender, EventArgs e) {
        OpenAccountButton.Enabled = false;
        RunTaskAsyncWithProgressBar("Initialize",
            ProgressBarStyle.Marquee,
            InitializeBackend,
            _ => OpenAccountButton.Enabled = true);
    }

    private void OnOpenAccount(object sender, EventArgs e) {
        if (openDatabaseDialog.ShowDialog() == DialogResult.OK) {
            var username = openDatabaseDialog.SelectedUser;
            OpenDatabase(username);
        }
    }

    private void OpenDatabase(string username) {
        RunTaskAsyncWithProgressBar($"Opening {username}...",
            ProgressBarStyle.Marquee,
            _ => OpenDatabaseTask(username),
            null);
    }

    private void InitializeBackend(ProgressBarStripDisplay.ProgressBarContainer progressBar) {
        databaseManager = new DatabaseManager(DatabaseDirectory);
        openDatabaseDialog = new OpenDatabaseDialog(databaseManager);
        BackendInitialized = true;
    }

    private void OpenDatabaseTask(string username) {
        var dao = databaseManager.OpenUser(username);
        var accountUI = new AccountExpenses(dao);
        Task.Run(accountUI.PreloadDataAsync).Wait();
        InvokeSafely(() => {
            AccountTabsContainer.TabPages.Add(accountUI.DAO.Name);
            AccountTabsContainer.TabPages[AccountTabsContainer.TabCount - 1].Controls.Add(accountUI);
            AccountTabsContainer.Visible = true;
            AccountTabsContainer.SelectedIndex = AccountTabsContainer.TabCount - 1;
            accountUI.Location = new Point(0, 0);
            accountUI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            accountUI.Size = AccountTabsContainer.TabPages[AccountTabsContainer.TabCount - 1].Size;
            openDatabases.Add(accountUI.DAO.Name, (accountUI, AccountTabsContainer.TabCount - 1));
            accountUI.RequestsClose += CloseDatabase;
        });
    }

    private void CloseDatabase(AccountExpenses sender) {
        var tab = AccountTabsContainer.TabPages[openDatabases[sender.DAO.Name].Item2];
        AccountTabsContainer.TabPages.Remove(tab);
        tab.Dispose();
        if (AccountTabsContainer.TabCount == 0)
            AccountTabsContainer.Visible = false;
        openDatabases.Remove(sender.DAO.Name);
        databaseManager.CloseUser(sender.DAO.Name);
        GC.Collect();
    }

    private void RunTaskAsyncWithProgressBar(string taskName, ProgressBarStyle progressBarStyle, Action<ProgressBarStripDisplay.ProgressBarContainer> action, Action<Task>? callback) {
        var container = StatusBarContainer.AddProgressBar(taskName, progressBarStyle);
        var task = Task.Run(() => action(container));
        if (callback is not null)
            task = task.ContinueWith((t) => InvokeSafely(callback, t));
        task.ContinueWith((_) => InvokeSafely(() => container.Dispose()));
    }

    private void InvokeSafely(Action action) {
        if (InvokeRequired)
            Invoke(action);
        else
            action();
    }

    private void InvokeSafely<T>(Action<T> action, T arg) {
        if (InvokeRequired)
            Invoke(action, arg);
        else
            action(arg);
    }

    private void OnResize(object sender, EventArgs e) => AccountTabsContainer.Refresh();

    private void CloseProgramButton_Click(object sender, EventArgs e) {
        if (!close)
            CloseProgram();
    }

    protected override void OnFormClosing(FormClosingEventArgs e) {
        if (e.CloseReason == CloseReason.UserClosing && !close)
            CloseProgram(e);
    }

    private void CloseProgram(FormClosingEventArgs? e = null) {
        if (MessageBoxUtils.ShowConfirmation("Close program?")) {
            close = true;
            Close();
        }
        else if (e is not null) {
            e.Cancel = true;
        }
    }

    private void ExportAsCsvButton_Click(object sender, EventArgs e) {
        if (openDatabases.Count == 0) {
            MessageBoxUtils.ShowError("No database open");
            return;
        }
        if (ExportDatabaseDialog.ShowDialog() != DialogResult.OK)
            return;
        var tab = AccountTabsContainer.SelectedTab;
        var dao = openDatabases[tab.Text].Item1.DAO;
        RunTaskAsyncWithProgressBar($"Exporting {tab.Name}",
            ProgressBarStyle.Marquee,
            (_) => ExpenseDaoExporter.ExportExpensesDaoAsync(ExportDatabaseDialog.FileName, dao).Wait(),
            (task) => PostCsvExportCallback(task, dao.Name));
    }

    private void PostCsvExportCallback(Task task, string username) {
        if (task.Exception is null)
            MessageBox.Show($"Account {username} exported as CSV successfully!", "Success");
        else
            MessageBoxUtils.ShowException($"Failed to export account {username} due to an error", task.Exception!.InnerException ?? task.Exception);
    }

    private void ImportUserButton_Click(object sender, EventArgs e) {
        if (importAccountDialog is null)
            importAccountDialog = new ImportAccountDialog();
        if (importAccountDialog.ShowDialog(databaseManager) != DialogResult.OK)
            return;
        RunTaskAsyncWithProgressBar($"Importing {importAccountDialog.AccountName}",
            ProgressBarStyle.Marquee,
            (_) => ExpenseDaoExporter.ImportExpensesDaoAsync(importAccountDialog.TransactionsFileName,
                                                                importAccountDialog.CategoriesFileName,
                                                                importAccountDialog.AccountName, databaseManager).Wait(),
            task => PostImportUserCallback(task, importAccountDialog.AccountName));
    }

    private void PostImportUserCallback(Task task, string username) {
        if (task.Exception is null)
            OpenDatabase(username);
        else {
            MessageBoxUtils.ShowException($"Failed to import account {username} due to an error", task.Exception!.InnerException ?? task.Exception);
            databaseManager.DeleteUser(username);
        }
    }
}
using System.IO;
using ExpenseManager.UI.Components;

namespace ExpenseManager.UI;

public partial class MainForm : Form
{
    private const string DatabaseDirectory = "Data/";
    private bool close;
    private OpenDatabaseDialog openDatabaseDialog;
    private DatabaseManager databaseManager;
    private Dictionary<string, (AccountExpenses, int)> openDatabases = new();
    public bool BackendInitialized { get; private set; }
    public MainForm() {
        InitializeComponent();
        FormClosing += OnFormClosing;
    }

    private void OnFormClosing(object? sender, FormClosingEventArgs e) {
        databaseManager.CloseAllUsers();
    }

    private void OnUIInitialized(object sender, EventArgs e) {
        OpenAccountButton.Enabled = false;
        RunTaskAsyncWithProgressBar("Initialize", ProgressBarStyle.Marquee, InitializeBackend, (t) => OpenAccountButton.Enabled = true);
    }

    private void OnOpenAccount(object sender, EventArgs e) {
        if (openDatabaseDialog.ShowDialog() == DialogResult.OK) {
            var username = openDatabaseDialog.SelectedUser;
            RunTaskAsyncWithProgressBar($"Opening {username}...", ProgressBarStyle.Marquee, (_) => OpenDatabase(username), null);
        }
    }

    private void InitializeBackend(ProgressBarStripDisplay.ProgressBarContainer progressBar) {
        databaseManager = new DatabaseManager(DatabaseDirectory);
        openDatabaseDialog = new OpenDatabaseDialog(databaseManager);
        BackendInitialized = true;
    }

    private void OpenDatabase(string username) {
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
        task = task.ContinueWith((task) => InvokeSafely(() => container.Dispose()));
        if (callback is not null)
            task.ContinueWith((t) => InvokeSafely(callback, t));
    }

    private void RunTaskAsync(Action action, Action<Task>? callback) {
        var task = Task.Run(action);
        if (callback is not null)
            task.ContinueWith((t) => InvokeSafely(callback, t));
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

    private void OnResize(object sender, EventArgs e) {
        AccountTabsContainer.Refresh();
    }

    private void CloseProgramButton_Click(object sender, EventArgs e) {
        if (!close)
            CloseProgram();
    }

    protected override void OnFormClosing(FormClosingEventArgs e) {
        if (e.CloseReason == CloseReason.UserClosing && !close)
            CloseProgram(e);
    }

    private void CloseProgram(FormClosingEventArgs? e = null) {
        if (MessageBox.Show("Close program?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
            close = true;
            Close();
        } else if (e is not null){
            e.Cancel = true;
        }
    }

    private void ExportAsCsvButton_Click(object sender, EventArgs e) {
        if (ExportDatabaseDialog.ShowDialog() != DialogResult.OK)
            return;
        var tab = AccountTabsContainer.SelectedTab;
        var dao = openDatabases[tab.Text].Item1.DAO;
        RunTaskAsyncWithProgressBar($"Exporting {tab.Name}", ProgressBarStyle.Marquee, (_) => ExportDatabaseAsync(dao, ExportDatabaseDialog.FileName).Wait(), null);
    }

    private async Task ExportDatabaseAsync(ExpensesDAO dao, string path) {
        await CSVExporter.ExportExpensesDaoAsync(path, dao);
    }
}
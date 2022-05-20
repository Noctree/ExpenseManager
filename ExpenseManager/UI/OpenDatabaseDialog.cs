namespace ExpenseManager.UI;

public partial class OpenDatabaseDialog : Form
{
    private TextboxDialog textboxDialog;
    private DatabaseManager databaseManager;

    /// <summary>
    /// Username which the user selected to open
    /// </summary>
    public string SelectedUser { get; private set; } = string.Empty;
    public OpenDatabaseDialog(DatabaseManager databaseManager) {
        this.databaseManager = databaseManager;
        textboxDialog = new TextboxDialog() {
            Title = "New Account Name",
            InvalidInputMessage = "Username already taken",
            InputVerifier = (username) => !databaseManager.ContainsUser(username)
        };
        InitializeComponent();
    }

    public new DialogResult ShowDialog() {
        AccountsListView.Items.Clear();
        foreach (string name in databaseManager.Users)
            AccountsListView.Items.Add(name);
        return base.ShowDialog();
    }

    private void OnCreateNewAccount(object sender, EventArgs e) {
        if (textboxDialog.ShowDialog() == DialogResult.OK) {
            databaseManager.CreateNewUser(textboxDialog.Text);
            Finish(DialogResult.OK, textboxDialog.Text);
        }
    }

    private void OnConfirm(object sender, EventArgs e) {
        Finish(DialogResult.OK, (string)AccountsListView.SelectedItem);
    }

    private void OnCancel(object sender, EventArgs e) {
        Finish(DialogResult.Cancel, string.Empty);
    }

    private void Finish(DialogResult result, string selectedUser) {
        if (result == DialogResult.OK && databaseManager.IsUserOpen(selectedUser)) {
            MessageBox.Show("Selected account is already open", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        SelectedUser = selectedUser;
        DialogResult = result;
        Close();
    }

    private void OnAccountListViewDoubleClick(object sender, EventArgs e) {
        if (AccountsListView.SelectedIndex >= 0)
            Finish(DialogResult.OK, (string)AccountsListView.SelectedItem);
    }
}

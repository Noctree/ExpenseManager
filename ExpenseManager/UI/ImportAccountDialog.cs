using System.IO;

namespace ExpenseManager.UI.Components;
public partial class ImportAccountDialog : Form
{
    private DatabaseManager databaseManager;

    public string TransactionsFileName { get; set; } = string.Empty;
    public string CategoriesFileName { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public ImportAccountDialog() {
        InitializeComponent();
    }

    public DialogResult ShowDialog(DatabaseManager databaseManager) {
        this.databaseManager = databaseManager;
        return base.ShowDialog();
    }

    private void SelectTransactionsButton_Click(object sender, EventArgs e) {
        if (OpenTransactionsFileDialog.ShowDialog() == DialogResult.OK) {
            TransactionsFileNameField.Text = OpenTransactionsFileDialog.FileName;
            var categoryFileName = ExpenseDaoExporter.GetCategoryFileName(OpenTransactionsFileDialog.FileName);
            if (File.Exists(categoryFileName))
                CategoriesFileNameField.Text = categoryFileName;
        }
    }

    private void SelectCategoriesButton_Click(object sender, EventArgs e) {
        if (OpenCategoriesFileDialog.ShowDialog() == DialogResult.OK)
            CategoriesFileNameField.Text = OpenCategoriesFileDialog.FileName;
    }

    private void CancellationButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void ConfirmationButton_Click(object sender, EventArgs e) {
        if (VerifyInput()) {
            TransactionsFileName = TransactionsFileNameField.Text;
            CategoriesFileName = CategoriesFileNameField.Text;
            AccountName = AccountNameField.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    private bool VerifyInput() {
        if (!File.Exists(TransactionsFileNameField.Text)) {
            MessageBoxUtils.ShowError($"File {TransactionsFileNameField.Text} does not exist!");
            return false;
        }
        if (!File.Exists(CategoriesFileNameField.Text)) {
            MessageBoxUtils.ShowError($"File {CategoriesFileNameField.Text} does not exist!");
            return false;
        }
        if (databaseManager.UserExists(AccountNameField.Text)) {
            MessageBoxUtils.ShowError($"Account {AccountNameField.Text} already exists!");
            return false;
        }
        return true;
    }
}

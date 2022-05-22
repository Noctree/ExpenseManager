using System.IO;

namespace ExpenseManager.UI.Components;
public partial class ImportAccountDialog : Form
{
    private DatabaseManager databaseManager;

    public string TransactionsFileName { get; set; }
    public string CategoriesFileName { get; set; }
    public string AccountName { get; set; }
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
            var categoryFileName = ExpenseDaoExporter.GetCategoryFileName(OpenCategoriesFileDialog.FileName);
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
            MessageBox.Show($"File {TransactionsFileNameField.Text} does not exist!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            return false;
        }
        if (!File.Exists(CategoriesFileNameField.Text)) {
            MessageBox.Show($"File {CategoriesFileNameField.Text} does not exist!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            return false;
        }
        if (databaseManager.UserExists(AccountNameField.Text)) {
            MessageBox.Show($"Account {AccountNameField.Text} already exists!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}

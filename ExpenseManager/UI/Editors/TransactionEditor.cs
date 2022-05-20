using ExpenseManager.DataObjects;
using System.Globalization;

namespace ExpenseManager.UI;
public partial class TransactionEditor : Form
{
    private ExpensesDAO dao;
    private Transaction transaction;
    private DateDialog datePicker = new DateDialog();
    public TransactionEditor(ExpensesDAO dao) {
        this.dao = dao;
        InitializeComponent();
    }

    public new DialogResult ShowDialog() => throw new NotSupportedException($"{nameof(TransactionEditor)} only supports {nameof(ShowDialog)} with provided {nameof(Transaction)}");

    public DialogResult ShowDialog(Transaction transaction) {
        this.transaction = transaction;
        LoadTransactionData(transaction);
        return base.ShowDialog();
    }

    private void LoadCategories() {
        CategoryComboBox.Items.Clear();
        var categories = dao.GetCategories();
        for (int i = 0; i < categories.Count; ++i) {
            CategoryComboBox.Items.Add(categories[i].Name);
        }
    }

    private void LoadTransactionData(Transaction transaction) {
        LoadCategories();
        DateField.Text = transaction.Date.ToString();
        AmountField.Text = transaction.Amount.ToString(CultureInfo.InvariantCulture);
        CategoryComboBox.SelectedIndex = (int)transaction.Category!.Id! - 1;
        DescriptionField.Text = transaction.Description;
    }

    private void ModifyTransaction(Transaction transaction) {
        transaction.Date = DateOnly.Parse(DateField.Text);
        transaction.Amount = decimal.Parse(AmountField.Text, NumberStyles.Currency, CultureInfo.InvariantCulture);
        Console.WriteLine($"{transaction.Category} | {dao.GetCategories()[CategoryComboBox.SelectedIndex]} | {CategoryComboBox.SelectedIndex}");
        transaction.Category = dao.GetCategories()[CategoryComboBox.SelectedIndex];
        transaction.Description = DescriptionField.Text;
    }

    private void DateField_Leave(object sender, EventArgs e) {
        if (!DateOnly.TryParse(DateField.Text, out var _)) {
            MessageBox.Show("Date is not valid", "Error", MessageBoxButtons.OK);
            DateField.Text = DateOnly.MinValue.ToString();
        }
    }

    private void AmountField_Leave(object sender, EventArgs e) {
        if (!decimal.TryParse(AmountField.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out var _)) {
            MessageBox.Show("Amount is not valid", "Error", MessageBoxButtons.OK);
            AmountField.Text = "0";
        }
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        ModifyTransaction(transaction);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void SelectDateButton_Click(object sender, EventArgs e) {
        if (datePicker.ShowDialog(DateOnly.Parse(DateField.Text).ToDateTime(new TimeOnly(0, 0, 0))) == DialogResult.OK)
            DateField.Text = DateOnly.FromDateTime(datePicker.SelectedDate).ToString();
    }
}

namespace ExpenseManager.UI;
public partial class AmountPicker : Form
{
    public decimal From { get; set; }
    public decimal To { get; set; }
    public AmountPicker() {
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e) {
        MinAmount.Value = From;
        MaxAmount.Value = To;
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        From = MinAmount.Value;
        To = MaxAmount.Value;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

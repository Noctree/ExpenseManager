namespace ExpenseManager.UI;
public partial class DateRangePicker : Form
{
    public DateOnly From { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly To { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateRangePicker() {
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e) {
        FromDatePicker.Value = From.ToDateTime(new TimeOnly(0, 0, 0));
        ToDatePicker.Value = To.ToDateTime(new TimeOnly(0, 0, 0));
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        From = DateOnly.FromDateTime(FromDatePicker.Value);
        To = DateOnly.FromDateTime(ToDatePicker.Value);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManager.UI;
public partial class DateDialog : Form
{
    public DateTime SelectedDate { get; private set; }
    public DateDialog() {
        InitializeComponent();
    }

    public new DialogResult ShowDialog() {
        Calendar.SetDate(DateTime.Today);
        return base.ShowDialog();
    }

    public DialogResult ShowDialog(DateTime date) {
        Calendar.SetDate(date);
        return base.ShowDialog();
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        SelectedDate = Calendar.SelectionStart;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        SelectedDate = DateTime.MinValue;
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

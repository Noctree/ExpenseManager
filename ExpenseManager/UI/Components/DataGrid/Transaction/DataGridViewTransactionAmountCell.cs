using ExpenseManager.DataObjects;

namespace ExpenseManager.UI.Components;
public class DataGridViewTransactionAmountCell : DataGridViewGenericTextBoxCell<Transaction>
{
    private static readonly Color NegativeBallanceColor = Color.FromArgb(204, 47, 47);
    private static readonly Color PositiveBallanceColor = Color.FromArgb(64, 132, 0);

    public DataGridViewTransactionAmountCell() {
        TextFormatter = transaction => transaction.Amount.ToString();
    }

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
        decimal amount = (value as Transaction)!.Amount;
        cellStyle.ForeColor = amount >= 0 ? PositiveBallanceColor : NegativeBallanceColor;
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
    }
}

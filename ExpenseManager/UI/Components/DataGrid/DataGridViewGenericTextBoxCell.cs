namespace ExpenseManager.UI.Components;

public class DataGridViewGenericTextBoxCell<T> : DataGridViewTextBoxCell
{
    protected virtual bool EnableDirectPaint => false;
    /// <summary>
    /// Converts the stored object to its text representation, the default ToString method is used if this property is not set
    /// </summary>
    public Func<T, string>? TextFormatter { get; set; }

    public new T Value => (T)base.Value;

    public override object Clone() {
        var clone = base.Clone();
        (clone as DataGridViewGenericTextBoxCell<T>)!.TextFormatter = TextFormatter;
        return clone;
    }

    protected override bool SetValue(int rowIndex, object value) {
        return value is not null and not T
            ? throw new ArgumentException($"Cell only accepts objects of type {typeof(T).Name}, value was {value} ({value.GetType().Name})")
            : base.SetValue(rowIndex, value);
    }

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
        if (EnableDirectPaint) {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            return;
        }
        if (value is null) {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, string.Empty, string.Empty, errorText, cellStyle, advancedBorderStyle, paintParts);
            return;
        }
        T realValue = (T)value;
        string stringRepresentation = TextFormatter is null ? realValue.ToString() ?? string.Empty : TextFormatter(realValue);
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, stringRepresentation, stringRepresentation, errorText, cellStyle, advancedBorderStyle, paintParts);
    }
}

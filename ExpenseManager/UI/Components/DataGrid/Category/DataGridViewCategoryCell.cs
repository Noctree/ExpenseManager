using ExpenseManager.DataObjects;

namespace ExpenseManager.UI;

public class DataGridViewCategoryCell : DataGridViewGenericTextBoxCell<Category>
{
    protected override bool EnableDirectPaint => true;
    protected override bool SetValue(int rowIndex, object value) {
        var result = base.SetValue(rowIndex, value);
        if (value is not null)
            OnValueUpdate((Category)value);
        return result;
    }

    protected virtual void OnValueUpdate(Category category) { }

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
        var category = value as Category;
        var categoryName = category is null ? string.Empty : category.Name;
        var categoryColor = category is null ? Color.White : category.Color;
        cellStyle.BackColor = categoryColor;
        cellStyle.ForeColor = categoryColor.GetBrightness() < 0.45f ? Color.White : Color.Black;
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, categoryName, categoryName, categoryName, cellStyle, advancedBorderStyle, paintParts);
    }
}

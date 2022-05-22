using ExpenseManager.DataObjects;

namespace ExpenseManager.UI.Components;

public class DataGridViewCategoryColorCell : DataGridViewCategoryCell
{
    private readonly SolidBrush brush = new(Color.White);

    protected override void OnValueUpdate(Category category) => brush.Color = category.Color;

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
        if (value is not null && brush.Color != ((Category)value).Color)
            brush.Color = ((Category)value).Color;
        graphics.FillRectangle(brush, cellBounds);
        PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
    }

    protected override void Dispose(bool disposing) {
        brush.Dispose();
        base.Dispose(disposing);
    }
}

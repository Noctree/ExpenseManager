namespace ExpenseManager.UI;
internal class ColorBox : Control
{
    private readonly ColorDialog dialog = new();
    private readonly SolidBrush brush = new(Color.White);
    private readonly Pen borderPen = new(Color.Black, 1);
    private Color color = Color.White;
    public Color SelectedColor {
        get => color;
        set {
            color = value;
            Refresh();
        }
    }

    protected override void OnClick(EventArgs e) {
        dialog.Color = SelectedColor;
        if (dialog.ShowDialog() == DialogResult.OK) {
            SelectedColor = dialog.Color;
            Refresh();
        }
        base.OnClick(e);
    }
    protected override void OnPaint(PaintEventArgs e) {
        brush.Color = SelectedColor;
        e.Graphics.FillRectangle(brush, e.ClipRectangle);
        e.Graphics.DrawRectangle(borderPen, e.ClipRectangle);
        base.OnPaint(e);
    }

    protected override void Dispose(bool disposing) {
        dialog.Dispose();
        brush.Dispose();
        borderPen.Dispose();
    }
}

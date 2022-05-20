using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.UI;
internal class ColorBox : Control
{
    private ColorDialog dialog = new ColorDialog();
    private SolidBrush brush = new SolidBrush(Color.White);
    private Pen borderPen = new Pen(Color.Black, 1);
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

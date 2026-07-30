namespace CafeManager.WinForms.Controls;

public sealed class RevenueChart : Control
{
    private IReadOnlyList<RevenuePoint> _points = Array.Empty<RevenuePoint>();

    public RevenueChart()
    {
        DoubleBuffered = true;
        BackColor = Color.White;
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(400, 240);
    }

    public void SetData(IEnumerable<RevenuePoint> points)
    {
        _points = points.ToList();
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        var area = new Rectangle(55, 25, Math.Max(50, Width - 80), Math.Max(50, Height - 75));
        using var axisPen = new Pen(Color.DimGray, 1);
        using var barBrush = new SolidBrush(Color.SteelBlue);
        using var textBrush = new SolidBrush(Color.Black);
        g.DrawLine(axisPen, area.Left, area.Top, area.Left, area.Bottom);
        g.DrawLine(axisPen, area.Left, area.Bottom, area.Right, area.Bottom);

        if (_points.Count == 0)
        {
            g.DrawString("Chưa có dữ liệu trong khoảng thời gian đã chọn.", Font, textBrush, area.Left + 20, area.Top + 30);
            return;
        }

        decimal max = Math.Max(1, _points.Max(x => x.Value));
        float slot = area.Width / (float)_points.Count;
        float barWidth = Math.Max(8, slot * 0.62f);

        for (int i = 0; i < _points.Count; i++)
        {
            var point = _points[i];
            float height = (float)(point.Value / max) * (area.Height - 25);
            float x = area.Left + i * slot + (slot - barWidth) / 2;
            float y = area.Bottom - height;
            g.FillRectangle(barBrush, x, y, barWidth, height);
            string value = point.Value >= 1_000_000 ? (point.Value / 1_000_000m).ToString("0.#") + "tr" : (point.Value / 1_000m).ToString("0") + "k";
            var valueSize = g.MeasureString(value, Font);
            g.DrawString(value, Font, textBrush, x + (barWidth - valueSize.Width) / 2, y - valueSize.Height - 2);
            string label = point.Label;
            var labelSize = g.MeasureString(label, Font);
            g.DrawString(label, Font, textBrush, x + (barWidth - labelSize.Width) / 2, area.Bottom + 5);
        }
    }
}

public sealed record RevenuePoint(string Label, decimal Value);

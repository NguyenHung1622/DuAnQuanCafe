using System.Drawing.Printing;
using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Services;

public static class InvoicePrinter
{
    public static void Preview(IWin32Window owner, int invoiceId)
    {
        using var db = new CafeDbContext();
        var invoice = db.Invoices.AsNoTracking()
            .Include(x => x.Table)
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .Include(x => x.Details)
                .ThenInclude(x => x.Product)
            .SingleOrDefault(x => x.Id == invoiceId);

        if (invoice is null)
        {
            Ui.Error("Không tìm thấy hóa đơn.");
            return;
        }

        var document = new PrintDocument { DocumentName = $"HoaDon_{invoice.Id}" };
        document.DefaultPageSettings.Margins = new Margins(45, 45, 45, 45);
        document.PrintPage += (_, e) => DrawInvoice(e.Graphics, e.MarginBounds, invoice);

        using var preview = new PrintPreviewDialog
        {
            Document = document,
            Width = 1000,
            Height = 760,
            StartPosition = FormStartPosition.CenterParent
        };
        preview.ShowDialog(owner);
        document.Dispose();
    }

    private static void DrawInvoice(Graphics graphics, Rectangle bounds, Invoice invoice)
    {
        using var titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
        using var headingFont = new Font("Segoe UI", 11, FontStyle.Bold);
        using var normalFont = new Font("Segoe UI", 10);
        using var smallFont = new Font("Segoe UI", 9);
        using var pen = new Pen(Color.Black, 1);

        float y = bounds.Top;
        var center = new StringFormat { Alignment = StringAlignment.Center };
        graphics.DrawString("CAFE MANAGER", titleFont, Brushes.Black, new RectangleF(bounds.Left, y, bounds.Width, 35), center);
        y += 40;
        graphics.DrawString("HÓA ĐƠN THANH TOÁN", headingFont, Brushes.Black, new RectangleF(bounds.Left, y, bounds.Width, 25), center);
        y += 35;

        graphics.DrawString($"Mã hóa đơn: {invoice.Id}", normalFont, Brushes.Black, bounds.Left, y);
        graphics.DrawString($"Bàn: {invoice.Table?.Name}", normalFont, Brushes.Black, bounds.Left + bounds.Width / 2, y);
        y += 24;
        graphics.DrawString($"Ngày: {(invoice.PaidAt ?? invoice.CreatedAt):dd/MM/yyyy HH:mm}", normalFont, Brushes.Black, bounds.Left, y);
        graphics.DrawString($"Nhân viên: {invoice.Employee?.FullName}", normalFont, Brushes.Black, bounds.Left + bounds.Width / 2, y);
        y += 24;
        graphics.DrawString($"Khách hàng: {invoice.Customer?.FullName ?? "Khách lẻ"}", normalFont, Brushes.Black, bounds.Left, y);
        y += 32;

        float xName = bounds.Left;
        float xQty = bounds.Left + bounds.Width * 0.55f;
        float xPrice = bounds.Left + bounds.Width * 0.68f;
        float xAmount = bounds.Left + bounds.Width * 0.84f;
        graphics.DrawLine(pen, bounds.Left, y, bounds.Right, y);
        y += 8;
        graphics.DrawString("Tên món", headingFont, Brushes.Black, xName, y);
        graphics.DrawString("SL", headingFont, Brushes.Black, xQty, y);
        graphics.DrawString("Đơn giá", headingFont, Brushes.Black, xPrice, y);
        graphics.DrawString("Thành tiền", headingFont, Brushes.Black, xAmount, y);
        y += 26;
        graphics.DrawLine(pen, bounds.Left, y, bounds.Right, y);
        y += 8;

        foreach (var detail in invoice.Details.OrderBy(x => x.Id))
        {
            graphics.DrawString(detail.Product?.Name ?? "", normalFont, Brushes.Black, new RectangleF(xName, y, bounds.Width * 0.53f, 25));
            graphics.DrawString(detail.Quantity.ToString(), normalFont, Brushes.Black, xQty, y);
            graphics.DrawString(detail.UnitPrice.ToString("N0"), normalFont, Brushes.Black, xPrice, y);
            graphics.DrawString((detail.Quantity * detail.UnitPrice).ToString("N0"), normalFont, Brushes.Black, xAmount, y);
            y += 25;
        }

        y += 5;
        graphics.DrawLine(pen, bounds.Left, y, bounds.Right, y);
        y += 12;
        DrawRight(graphics, normalFont, "Tạm tính:", invoice.Subtotal, bounds, ref y);
        DrawRight(graphics, normalFont, "Giảm giá:", invoice.Discount, bounds, ref y);
        DrawRight(graphics, headingFont, "TỔNG TIỀN:", invoice.Total, bounds, ref y);
        y += 20;
        graphics.DrawString("Cảm ơn quý khách và hẹn gặp lại!", smallFont, Brushes.Black, new RectangleF(bounds.Left, y, bounds.Width, 25), center);
    }

    private static void DrawRight(Graphics graphics, Font font, string label, decimal amount, Rectangle bounds, ref float y)
    {
        graphics.DrawString(label, font, Brushes.Black, bounds.Left + bounds.Width * 0.60f, y);
        graphics.DrawString(amount.ToString("N0") + " đ", font, Brushes.Black, bounds.Left + bounds.Width * 0.82f, y);
        y += 26;
    }
}

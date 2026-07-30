using System.Security;
using System.Text;

namespace CafeManager.WinForms.Helpers;

public static class ExcelXmlExporter
{
    public static void ExportRevenue(string path, IEnumerable<RevenueExportRow> rows, DateTime from, DateTime to)
    {
        static string E(string value) => SecurityElement.Escape(value) ?? string.Empty;
        var data = rows.ToList();
        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\"?>");
        sb.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
        sb.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
        sb.AppendLine("<Styles><Style ss:ID=\"Header\"><Font ss:Bold=\"1\"/><Interior ss:Color=\"#D9EAF7\" ss:Pattern=\"Solid\"/></Style></Styles>");
        sb.AppendLine("<Worksheet ss:Name=\"Doanh thu\"><Table>");
        sb.AppendLine("<Row><Cell ss:StyleID=\"Header\"><Data ss:Type=\"String\">BÁO CÁO DOANH THU</Data></Cell></Row>");
        sb.AppendLine($"<Row><Cell><Data ss:Type=\"String\">Từ {from:dd/MM/yyyy} đến {to:dd/MM/yyyy}</Data></Cell></Row>");
        sb.AppendLine("<Row></Row>");
        sb.AppendLine("<Row><Cell ss:StyleID=\"Header\"><Data ss:Type=\"String\">Ngày</Data></Cell><Cell ss:StyleID=\"Header\"><Data ss:Type=\"String\">Số hóa đơn</Data></Cell><Cell ss:StyleID=\"Header\"><Data ss:Type=\"String\">Doanh thu</Data></Cell></Row>");
        foreach (var row in data)
        {
            sb.AppendLine($"<Row><Cell><Data ss:Type=\"String\">{E(row.Date)}</Data></Cell><Cell><Data ss:Type=\"Number\">{row.InvoiceCount}</Data></Cell><Cell><Data ss:Type=\"Number\">{row.Revenue}</Data></Cell></Row>");
        }
        sb.AppendLine($"<Row><Cell ss:StyleID=\"Header\"><Data ss:Type=\"String\">Tổng</Data></Cell><Cell ss:StyleID=\"Header\"><Data ss:Type=\"Number\">{data.Sum(x => x.InvoiceCount)}</Data></Cell><Cell ss:StyleID=\"Header\"><Data ss:Type=\"Number\">{data.Sum(x => x.Revenue)}</Data></Cell></Row>");
        sb.AppendLine("</Table></Worksheet></Workbook>");
        File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));
    }
}

public sealed record RevenueExportRow(string Date, int InvoiceCount, decimal Revenue);

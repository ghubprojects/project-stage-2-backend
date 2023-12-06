using MISA.SME2023.Common;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace MISA.SME2023.BL
{
    /// <summary>
    /// Lớp hỗ trợ xuất dữ liệu vào file Excel
    /// </summary>
    public static class ExportToExcelHelper<T> where T : class
    {
        /// <summary>
        /// Tạo dữ liệu cho file Excel
        /// </summary>
        /// <param name="dataList">Danh sách đối tượng export</param>
        /// <param name="templateFileInfo">Thông tin về file Excel mẫu</param>
        /// <returns>Dữ liệu cho file Excel</returns>
        /// <remarks>Created by: ttanh (02/10/2023)</remarks>
        public static byte[] GenerateExcelFile(List<T> dataList, long totalValue, FileInfo templateFileInfo)
        {
            // Thiết lập license context của EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(templateFileInfo))
            {
                // Lấy trang chứa dữ liệu cần export
                var worksheet = package.Workbook.Worksheets[0];

                // Điền dữ liệu vào sheet bắt đầu từ hàng 4 với số thứ tự là 1
                int currentRow = 4;
                int index = 1;

                // Xoá dữ liệu mẫu và border style từng hàng của file template excel
                for (var row = currentRow; row <= worksheet.Dimension.End.Row; row++)
                {
                    for (var col = 1; col < worksheet.Dimension.End.Column; col++)
                    {
                        worksheet.Cells[row, col].Value = "";
                    }

                    var rowRange = worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column];

                    // Set background color to white
                    rowRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rowRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);

                    // Remove bold style
                    rowRange.Style.Font.Bold = false;

                    rowRange.Style.Border.Top.Style = ExcelBorderStyle.None;
                    rowRange.Style.Border.Left.Style = ExcelBorderStyle.None;
                    rowRange.Style.Border.Right.Style = ExcelBorderStyle.None;
                    rowRange.Style.Border.Bottom.Style = ExcelBorderStyle.None;
                }

                foreach (var data in dataList)
                {
                    // Điền số thứ tự nhân viên ở cột 1
                    worksheet.Cells[currentRow, 1].Value = index;

                    // Từ cột 2 trở đi, điền dữ liệu nhân viên
                    int currentCol = 2;
                    foreach (var property in typeof(PaymentExportDTO).GetProperties())
                    {
                        var cellValue = property.GetValue(data);
                        worksheet.Cells[currentRow, currentCol].Value = cellValue;
                        currentCol++;
                    }

                    // Áp dụng border cho những hàng mới được thêm
                    var rowRange = worksheet.Cells[currentRow, 1, currentRow, worksheet.Dimension.End.Column];
                    rowRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    rowRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    rowRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    rowRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    index++;
                    currentRow++;
                }

                // Thêm hàng tổng ở cuối danh sách
                worksheet.Cells[currentRow, 2].Value = "Tổng";

                // Set bold
                worksheet.Cells[currentRow, 1, currentRow, worksheet.Dimension.End.Column].Style.Font.Bold = true;

                // Set background color (Darker 15%)
                worksheet.Cells[currentRow, 1, currentRow, worksheet.Dimension.End.Column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[currentRow, 1, currentRow, worksheet.Dimension.End.Column].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#DDDDDD"));

                // Set total amount sum
                worksheet.Cells[currentRow, 6].Value = totalValue;
                // Format as currency
                worksheet.Cells[currentRow, 6].Style.Numberformat.Format = "#,##0";

                // Áp dụng border cho hàng tổng
                var totalRowRange = worksheet.Cells[currentRow, 1, currentRow, worksheet.Dimension.End.Column];
                totalRowRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                totalRowRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                totalRowRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                totalRowRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                return package.GetAsByteArray();
            }
        }
    }
}

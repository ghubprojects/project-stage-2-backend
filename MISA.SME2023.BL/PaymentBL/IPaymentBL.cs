using MISA.SME2023.Common;

namespace MISA.SME2023.BL
{
    public interface IPaymentBL : IBaseBL<Payment>
    {
        Task<byte[]> ExportToExcelAsync(string? keyword);
    }
}

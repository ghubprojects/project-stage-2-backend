using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public interface IPaymentDL : IBaseDL<Payment>
    {
        Task<List<Payment>> GetAllExportAsync(string? keyword);

        Task<long> GetTotalAmountSumAsync();

        Task<dynamic> GetByNumberAsync(string accountNumber);
    }
}

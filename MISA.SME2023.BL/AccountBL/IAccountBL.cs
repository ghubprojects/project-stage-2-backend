using MISA.SME2023.Common;

namespace MISA.SME2023.BL
{
    public interface IAccountBL : IBaseBL<Account>
    {
        Task<ServiceResult> UpdateInactiveAsync(Guid id, bool inactive, bool forceChild);
    }
}

using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public interface IAccountDL : IBaseDL<Account>
    {
        Task UpdateInactiveAsync(Guid id, bool inactive, bool forceChild, string modifiedBy);

        Task<dynamic> GetByNumberAsync(string accountNumber);

        Task<int> GetGradeByIdAsync(Guid accountId);

        Task UpdateIsParentAsync(string accountNumber);
    }
}

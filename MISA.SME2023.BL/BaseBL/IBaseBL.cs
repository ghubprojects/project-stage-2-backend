using MISA.SME2023.Common;

namespace MISA.SME2023.BL
{
    public interface IBaseBL<T> where T : class
    {
        #region Methods

        Task<ServiceResult> GetAllAsync(string? keyword, int? limit, int? offset);

        Task<ServiceResult> GetAllDetailsAsync(Guid id, string? keyword, int? limit, int? offset);

        Task<ServiceResult> GetByIdAsync(Guid id);

        Task<ServiceResult> AddAsync(T entity);

        Task<ServiceResult> AddMultipleAsync(IEnumerable<T> entities);

        Task<ServiceResult> UpdateAsync(T entity);

        Task<ServiceResult> UpdateMultipleAsync(IEnumerable<T> entities);

        Task<ServiceResult> DeleteAsync(T entity);

        Task<ServiceResult> DeleteMultipleAsync(IEnumerable<T> entities);

        #endregion
    }
}

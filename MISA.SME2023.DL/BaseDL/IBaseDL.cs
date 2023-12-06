using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public interface IBaseDL<T> where T : class
    {
        #region Methods

        Task<DataResult<dynamic>> GetAllAsync(string? keyword, int? limit, int? offset);

        Task<DataResult<dynamic>> GetAllDetailsAsync(Guid id, string? keyword, int? limit, int? offset);

        Task<dynamic> GetByIdAsync(Guid id);

        Task AddAsync(T entity);

        Task AddMultipleAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task UpdateMultipleAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task DeleteMultipleAsync(IEnumerable<T> entities);

        #endregion
    }
}

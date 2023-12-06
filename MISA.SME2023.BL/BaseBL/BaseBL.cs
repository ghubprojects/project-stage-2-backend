using MISA.SME2023.Common;
using MISA.SME2023.DL;

namespace MISA.SME2023.BL
{
    public class BaseBL<T> : IBaseBL<T> where T : class
    {

        #region Field

        private readonly IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        public virtual async Task<ServiceResult> GetAllAsync(string? keyword, int? limit, int? offset)
        {
            return new ServiceResult(await _baseDL.GetAllAsync(keyword, limit, offset));
        }

        public virtual async Task<ServiceResult> GetByIdAsync(Guid id)
        {
            return new ServiceResult(await _baseDL.GetByIdAsync(id));
        }

        public virtual async Task<ServiceResult> GetAllDetailsAsync(Guid id, string? keyword, int? limit, int? offset)
        {
            return new ServiceResult(await _baseDL.GetAllDetailsAsync(id, keyword, limit, offset));
        }

        #region AddMethods

        public virtual async Task<ServiceResult> AddAsync(T data)
        {
            if (data is IEntity entity && entity.GetId() == Guid.Empty)
            {
                entity.SetId(Guid.NewGuid());
            }

            if (data is AuditableBaseEntity baseAuditEntity)
            {
                baseAuditEntity.created_by = "Admin";
                baseAuditEntity.created_date = DateTime.Now;
                baseAuditEntity.modified_by = "Admin";
                baseAuditEntity.modified_date = DateTime.Now;
            }

            await _baseDL.AddAsync(data);
            return new ServiceResult();
        }

        public virtual async Task<ServiceResult> AddMultipleAsync(IEnumerable<T> dataList)
        {
            foreach (var data in dataList)
            {
                if (data is IEntity entity && entity.GetId() == Guid.Empty)
                {
                    entity.SetId(Guid.NewGuid());
                }

                if (data is AuditableBaseEntity baseAuditEntity)
                {
                    baseAuditEntity.created_by = "Admin";
                    baseAuditEntity.created_date = DateTime.Now;
                    baseAuditEntity.modified_by = "Admin";
                    baseAuditEntity.modified_date = DateTime.Now;
                }
            }

            await _baseDL.AddMultipleAsync(dataList);
            return new ServiceResult();
        }

        #endregion

        #region UpdateMethods

        public virtual async Task<ServiceResult> UpdateAsync(T data)
        {
            if (data is AuditableBaseEntity baseAuditEntity)
            {
                baseAuditEntity.modified_by = "Admin";
                baseAuditEntity.modified_date = DateTime.Now;
            }

            await _baseDL.UpdateAsync(data);
            return new ServiceResult();
        }

        public virtual async Task<ServiceResult> UpdateMultipleAsync(IEnumerable<T> dataList)
        {
            foreach (var data in dataList)
            {
                if (data is AuditableBaseEntity baseAuditEntity)
                {
                    baseAuditEntity.modified_by = "Admin";
                    baseAuditEntity.modified_date = DateTime.Now;
                }
            }

            await _baseDL.AddMultipleAsync(dataList);
            return new ServiceResult();
        }

        #endregion

        #region DeleteMethods

        public virtual async Task<ServiceResult> DeleteAsync(T data)
        {
            await _baseDL.DeleteAsync(data);
            return new ServiceResult();
        }

        public virtual async Task<ServiceResult> DeleteMultipleAsync(IEnumerable<T> dataList)
        {
            await _baseDL.AddMultipleAsync(dataList);
            return new ServiceResult();
        }

        #endregion

        #endregion

    }
}

namespace MISA.SME2023.Common
{
    public class Department : AuditableBaseEntity, IEntity
    {
        #region Properties

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid? department_id { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string department_code { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string description { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Lấy giá trị ID của đơn vị.
        /// </summary>
        /// <returns>Giá trị ID của đơn vị.</returns>
        public Guid GetId()
        {
            return department_id ?? Guid.Empty;
        }

        /// <summary>
        /// Thiết lập giá trị ID cho đơn vị.
        /// </summary>
        /// <param name="id">Giá trị ID mới.</param>
        public void SetId(Guid id)
        {
            department_id = id;
        }

        #endregion
    }
}

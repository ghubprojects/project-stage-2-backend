namespace MISA.SME2023.Common
{
    /// <summary>
    /// Thực thể cơ sở ghi nhận thông tin
    /// </summary>
    /// Created by: ttanh (05/09/2023)
    public abstract class AuditableBaseEntity
    {
        #region Property

        /// <summary>
        /// Thời gian khởi tạo
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// Người khởi tạo
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// Thời gian chỉnh sửa
        /// </summary>
        public DateTime? modified_date { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string? modified_by { get; set; }

        #endregion
    }
}

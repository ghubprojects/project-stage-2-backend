using System.ComponentModel.DataAnnotations;

namespace MISA.SME2023.Common
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    public class Employee : AuditableBaseEntity, IEntity
    {
        #region Property

        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid employee_id { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required]
        [StringLength(20)]
        public string employee_code { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required]
        [StringLength(100)]
        public string full_name { get; set; } = string.Empty;

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? date_of_birth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender gender { get; set; }
        /// <summary>
        /// Số căn cước công dân
        /// </summary>
        [StringLength(25)]
        public string identity_number { get; set; } = string.Empty;

        /// <summary>
        /// Ngày cấp căn cước công dân
        /// </summary>
        public DateTime? identity_date { get; set; }

        /// <summary>
        /// Nơi cấp căn cước công dân
        /// </summary>
        [StringLength(255)]
        public string identity_place { get; set; } = string.Empty;

        /// <summary>
        /// Chức danh
        /// </summary>
        [StringLength(100)]
        public string position_name { get; set; } = string.Empty;

        /// <summary>
        /// ID đơn vị
        /// </summary>
        public Guid department_id { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(255)]
        public string address { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(100)]
        public string email { get; set; } = string.Empty;

        /// <summary>
        /// Số điện thoại di động.
        /// </summary>
        [StringLength(50)]
        public string mobile_phone { get; set; } = string.Empty;

        /// <summary>
        /// Số điện thoại cố định.
        /// </summary>
        [StringLength(50)]
        public string landline_phone { get; set; } = string.Empty;

        /// <summary>
        /// Tài khoản ngân hàng.
        /// </summary>
        [StringLength(25)]
        public string bank_account { get; set; } = string.Empty;

        /// <summary>
        /// Tên ngân hàng.
        /// </summary>
        [StringLength(255)]
        public string bank_name { get; set; } = string.Empty;

        /// <summary>
        /// /// Chi nhánh ngân hàng.
        /// </summary>
        [StringLength(255)]
        public string bank_branch { get; set; } = string.Empty;

        #endregion

        #region Methods

        /// <summary>
        /// Lấy giá trị ID của đơn vị.
        /// </summary>
        /// <returns>Giá trị ID của đơn vị.</returns>
        public Guid GetId()
        {
            return employee_id;
        }

        /// <summary>
        /// Thiết lập giá trị ID cho đơn vị.
        /// </summary>
        /// <param name="id">Giá trị ID mới.</param>
        public void SetId(Guid id)
        {
            employee_id = id;
        }

        #endregion
    }
}
using System.ComponentModel.DataAnnotations;

namespace MISA.SME2023.Common
{
    public class Payment : AuditableBaseEntity, IEntity
    {
        public Guid payment_id { get; set; }

        [Required(ErrorMessage = "Số phiếu chi không được để trống.")]
        [StringLength(20, ErrorMessage = "Số phiếu chi không được vượt quá 20 ký tự.")]
        public string payment_number { get; set; }

        [Required(ErrorMessage = "Ngày chứng từ không được để trống.")]
        public DateTime payment_date { get; set; }

        [Required(ErrorMessage = "Ngày hạch toán không được để trống.")]
        public DateTime posted_date { get; set; }

        public int? document_included { get; set; }

        public string? journal_memo { get; set; }

        public long? total_amount { get; set; }

        public Guid? supplier_id { get; set; }

        [StringLength(20, ErrorMessage = "Mã nhà cung cấp không được vượt quá 20 ký tự.")]
        public string? supplier_code { get; set; }

        [StringLength(100, ErrorMessage = "Tên nhà cung cấp không được vượt quá 100 ký tự.")]
        public string? supplier_name { get; set; }

        [StringLength(255, ErrorMessage = "Tên liên hệ không được vượt quá 255 ký tự.")]
        public string? supplier_contact_name { get; set; }

        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự.")]
        public string? supplier_address { get; set; }

        public Guid? employee_id { get; set; }

        [StringLength(20, ErrorMessage = "Mã nhân viên không được vượt quá 20 ký tự.")]
        public string? employee_code { get; set; }

        [StringLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự.")]
        public string? employee_name { get; set; }

        #region Methods

        /// <summary>
        /// Lấy giá trị ID của đơn vị.
        /// </summary>
        /// <returns>Giá trị ID của đơn vị.</returns>
        public Guid GetId()
        {
            return payment_id;
        }

        /// <summary>
        /// Thiết lập giá trị ID cho đơn vị.
        /// </summary>
        /// <param name="id">Giá trị ID mới.</param>
        public void SetId(Guid id)
        {
            payment_id = id;
        }

        #endregion
    }
}

using System.ComponentModel.DataAnnotations;

namespace MISA.SME2023.Common
{
    public class Account : AuditableBaseEntity, IEntity
    {
        public Guid account_id { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "Số tài khoản không được để trống.")]
        [MinLength(3, ErrorMessage = "Số tài khoản phải có độ dài ít nhất 3 ký tự.")]
        [StringLength(25, ErrorMessage = "Số tài khoản không được vượt quá 25 ký tự.")]
        //[UniqueAccountNumber(ErrorMessage = "Số tài khoản đã tồn tại. Xin vui lòng kiểm tra lại.")]
        public string account_number { get; set; }

        public string current_account_number { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống.")]
        [StringLength(255, ErrorMessage = "Tên tài khoản không được vượt quá 255 ký tự.")]
        public string account_name { get; set; }

        [StringLength(255, ErrorMessage = "Tên tiếng Anh của tài khoản không được vượt quá 255 ký tự.")]
        public string? account_name_english { get; set; }

        [Required(ErrorMessage = "Tính chất không được để trống.")]
        [EnumDataType(typeof(AccountCategory), ErrorMessage = "Tính chất không hợp lệ.")]
        public AccountCategory account_category { get; set; }

        [StringLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự.")]
        public string? description { get; set; }

        public bool inactive { get; set; }

        public int grade { get; set; }

        public bool is_parent { get; set; }

        public Guid? parent_id { get; set; }

        [StringLength(25, ErrorMessage = "Tài khoản cha không được vượt quá 25 ký tự.")]
        public string? parent_account { get; set; }

        public bool? is_postable_in_foreign_currency { get; set; }

        public int? detail_by_account_object { get; set; }
        public int? detail_by_job { get; set; }
        public int? detail_by_project_work { get; set; }
        public int? detail_by_order { get; set; }
        public int? detail_by_contract { get; set; }
        public int? detail_by_pu_contract { get; set; }
        public int? detail_by_expense_item { get; set; }
        public int? detail_by_department { get; set; }
        public int? detail_by_list_item { get; set; }

        public bool? is_detail_by_account_object { get; set; }
        public bool? is_detail_by_bank_account { get; set; }
        public bool? is_detail_by_job { get; set; }
        public bool? is_detail_by_project_work { get; set; }
        public bool? is_detail_by_order { get; set; }
        public bool? is_detail_by_contract { get; set; }
        public bool? is_detail_by_pu_contract { get; set; }
        public bool? is_detail_by_expense_item { get; set; }
        public bool? is_detail_by_department { get; set; }
        public bool? is_detail_by_list_item { get; set; }

        #region Methods

        /// <summary>
        /// Lấy giá trị ID của đơn vị.
        /// </summary>
        /// <returns>Giá trị ID của đơn vị.</returns>
        public Guid GetId()
        {
            return account_id;
        }

        /// <summary>
        /// Thiết lập giá trị ID cho đơn vị.
        /// </summary>
        /// <param name="id">Giá trị ID mới.</param>
        public void SetId(Guid id)
        {
            account_id = id;
        }

        #endregion
    }
}

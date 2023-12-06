using System.ComponentModel.DataAnnotations;

namespace MISA.SME2023.Common
{
    public class Supplier : AuditableBaseEntity, IEntity
    {
        public Guid supplier_id { get; set; }

        [Required]
        [StringLength(20)]
        public string supplier_code { get; set; }

        public string? supplier_name { get; set; }

        public string? supplier_contact_name { get; set; }

        public string? address { get; set; }

        public string? phone_number { get; set; }

        #region Methods

        /// <summary>
        /// Lấy giá trị ID của đơn vị.
        /// </summary>
        /// <returns>Giá trị ID của đơn vị.</returns>
        public Guid GetId()
        {
            return supplier_id;
        }

        /// <summary>
        /// Thiết lập giá trị ID cho đơn vị.
        /// </summary>
        /// <param name="id">Giá trị ID mới.</param>
        public void SetId(Guid id)
        {
            supplier_id = id;
        }

        #endregion
    }
}

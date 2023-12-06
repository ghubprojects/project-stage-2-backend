namespace MISA.SME2023.Common
{
    public class PaymentDetail : AuditableBaseEntity, IEntity
    {
        public Guid payment_detail_id { get; set; }

        public Guid payment_id { get; set; }

        public string description { get; set; }

        public string debit_account { get; set; }

        public string credit_account { get; set; }

        public int? amount { get; set; }

        #region Methods

        /// <summary>
        /// Lấy giá trị ID của đơn vị.
        /// </summary>
        /// <returns>Giá trị ID của đơn vị.</returns>
        public Guid GetId()
        {
            return payment_detail_id;
        }

        /// <summary>
        /// Thiết lập giá trị ID cho đơn vị.
        /// </summary>
        /// <param name="id">Giá trị ID mới.</param>
        public void SetId(Guid id)
        {
            payment_detail_id = id;
        }

        #endregion
    }
}

namespace MISA.SME2023.Common
{
    public class PaymentExportDTO
    {
        /// <summary>
        /// Ngày hạch toán
        /// </summary>
        public string? posted_date { get; set; }

        /// <summary>
        /// Ngày phiếu chi
        /// </summary>
        public string? payment_date { get; set; }

        /// <summary>
        /// Số phiếu chi
        /// </summary>
        public string payment_number { get; set; }

        /// <summary>
        /// Diễn giải
        /// </summary>
        public string? journal_memo { get; set; }

        public string? total_amount { get; set; }

        public string? supplier_code { get; set; }

        public string? supplier_name { get; set; }

        public string? supplier_address { get; set; }

        public string payment_reason { get; set; } = "Chi khác";

        public string? payment_type { get; set; } = "Phiếu chi";
    }
}
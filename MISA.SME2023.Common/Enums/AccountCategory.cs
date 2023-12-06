namespace MISA.SME2023.Common
{
    public enum AccountCategory
    {
        /// <summary>
        /// Dư nợ
        /// </summary>
        Debit = 0,

        /// <summary>
        /// Dư có
        /// </summary>
        Credit = 1,

        /// <summary>
        /// Lưỡng tính
        /// </summary>
        Neutral = 2,

        /// <summary>
        /// Không có số dư
        /// </summary>
        NoBalance = 3
    }
}

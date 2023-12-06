namespace MISA.SME2023.Common
{
    public static class ExcelConfig
    {
        public static List<string> getAccountColName()
        {
            List<string> list = new()
            {
                "Số tài khoản",
                "Tên tài khoản",
                "Tính chất",
                "Tên tiếng anh",
                "Diễn giải",
                "Trạng thái"
            };
            return list;
        }

        public static List<string> getAccountModelName()
        {
            List<string> list = new()
            {
                "AccountNumber",
                "AccountName",
                "Property",
                "EnglishName",
                "Description",
                "Status"
            };
            return list;
        }

        public static List<String> AccountPropertyValue()
        {
            List<string> list = new()
            {
                "Dư nợ",
                "Dư có",
                "Lưỡng tính",
                "Không có số dư"
            };
            return list;
        }

        public static List<String> AccountStatusValue()
        {
            List<string> list = new()
            {
                "Đang sử dụng",
                "Ngưng sử dụng"
            };
            return list;
        }

        public static List<String> GetPaymentColName()
        {
            List<String> list = new()
            {
                "STT",
                "Ngày hạch toán",
                "Ngày chứng từ",
                "Số chứng từ",
                "Số tiền",
                "Mã đối tượng",
                "Đối tượng",
                "Lý do thu/chi",
                "Loại chứng từ",
                "Hạch toán gộp nhiều hóa đơn"
            };
            return list;
        }

        public static List<String> GetPaymentModelName()
        {
            List<String> list = new()
            {
                "num",
                "re_date",
                "ca_date",
                "re_ref_no",
                "amount",
                "supplier_code",
                "supplier_name",
                "re_reason",
                "ca_type",
                "multiple_payment"
            };
            return list;
        }
    }
}

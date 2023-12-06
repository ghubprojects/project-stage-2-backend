using AutoMapper;
using MISA.SME2023.Common;

namespace MISA.SME2023.BL
{
    /// <summary>
    /// Lớp chứa cấu hình AutoMapper cho đối tượng Payment
    /// </summary>
    public class PaymentProfile : Profile
    {
        /// <summary>
        /// Hàm khởi tạo của PaymentProfile để cấu hình mapping
        /// </summary>
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentExportDTO>()
                .ForMember(des => des.posted_date, otp => otp.MapFrom(src => ConvertDateToString(src.posted_date)))
                .ForMember(des => des.payment_date, otp => otp.MapFrom(src => ConvertDateToString(src.payment_date)))
                .ForMember(des => des.total_amount, otp => otp.MapFrom(src => FormatAmount(src.total_amount)));
        }

        /// <summary>
        /// Chuyển đổi thời gian từ DateTime sang DateOnly để hiển thị trong file excel
        /// </summary>
        /// <param name="date">Đối tượng thời gian theo DateTime</param>
        /// <returns>Chuỗi ngày tháng năm</returns>
        /// <remarks>Created by: ttanh (02/10/2023)</remarks>
        private dynamic ConvertDateToString(DateTime? date)
        {
            if (!date.HasValue)
                return "";

            // Chuyển đổi DateTime sang DateOnly.
            var dateOnly = new DateOnly(date.Value.Year, date.Value.Month, date.Value.Day);

            return dateOnly.ToString("dd/MM/yyyy");
        }

        private string FormatAmount(long? amount)
        {
            return string.Format("{0:N0}", amount);
        }
    }
}

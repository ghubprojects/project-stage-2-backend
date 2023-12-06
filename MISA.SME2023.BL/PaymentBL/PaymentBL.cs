using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using MISA.SME2023.Common;
using MISA.SME2023.DL;

namespace MISA.SME2023.BL
{
    public class PaymentBL : BaseBL<Payment>, IPaymentBL
    {
        private readonly IHostingEnvironment _env;

        private readonly IPaymentDL _paymentDL;

        private readonly IMapper _mapper;

        public PaymentBL(IBaseDL<Payment> baseDL, IPaymentDL paymentDL, IHostingEnvironment env, IMapper mapper) : base(baseDL)
        {
            _paymentDL = paymentDL;
            _env = env;
            _mapper = mapper;
        }

        /// <summary>
        /// Xuất khẩu danh sách ra excel
        /// </summary>
        /// <returns>Dữ liệu file excel</returns>
        /// Created by: ttanh (02/10/2023)
        public async Task<byte[]> ExportToExcelAsync(string? keyword)
        {
            // Lấy dữ liệu từ database
            var dataList = await _paymentDL.GetAllExportAsync(keyword);
            var totalAmountSum = await _paymentDL.GetTotalAmountSumAsync();

            var dataListExport = _mapper.Map<List<PaymentExportDTO>>(dataList);

            // Define đường dẫn tới file excel mẫu
            var templateFileInfo = new FileInfo(Path.Combine(_env.ContentRootPath, "Template", $"{typeof(Payment).Name}.xlsx"));

            // Gọi đến helper để lấy dữ liệu cho file excel
            var excelData = ExportToExcelHelper<PaymentExportDTO>.GenerateExcelFile(dataListExport, totalAmountSum, templateFileInfo);

            return excelData;
        }

        override public async Task<ServiceResult> AddAsync(Payment data)
        {
            await CheckExistPaymentNumberAsync(data.payment_number);
            IsValidPostedDate(data.posted_date, data.payment_date);

            if (data is IEntity entity && entity.GetId() == Guid.Empty)
            {
                entity.SetId(Guid.NewGuid());
            }

            if (data is AuditableBaseEntity baseAuditEntity)
            {
                baseAuditEntity.created_by = "Admin";
                baseAuditEntity.created_date = DateTime.Now;
                baseAuditEntity.modified_by = "Admin";
                baseAuditEntity.modified_date = DateTime.Now;
            }

            await _paymentDL.AddAsync(data);
            return new ServiceResult();
        }

        override public async Task<ServiceResult> UpdateAsync(Payment data)
        {
            await CheckExistPaymentNumberAsync(data.payment_number);
            IsValidPostedDate(data.posted_date, data.payment_date);

            if (data is AuditableBaseEntity baseAuditEntity)
            {
                baseAuditEntity.modified_by = "Admin";
                baseAuditEntity.modified_date = DateTime.Now;
            }

            await _paymentDL.UpdateAsync(data);
            return new ServiceResult();
        }

        public async Task CheckExistPaymentNumberAsync(string paymentNumber)
        {
            var searchResult = await _paymentDL.GetByNumberAsync(paymentNumber);

            var errorMessage = $"Số chứng từ {paymentNumber} đã tồn tại. Xin vui lòng kiểm tra lại.";

            if (searchResult != null)
                throw new ValidationException(errorMessage, (int)ErrorCode.DuplicatedPaymentNumber);
        }

        public void IsValidPostedDate(DateTime postedDate, DateTime paymentDate)
        {
            var errorMessage = $"Ngày hạch toán phải lớn hơn hoặc bằng ngày chứng từ. Xin vui lòng kiểm tra lại.";

            if (DateTime.Compare(postedDate, paymentDate) < 0)
                throw new ValidationException(errorMessage, (int)ErrorCode.InvalidPostedDate);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MISA.SME2023.BL;
using MISA.SME2023.Common;

namespace MISA.SME2023.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController<Payment>
    {
        private readonly IPaymentBL _paymentBL;

        public PaymentsController(IBaseBL<Payment> baseBL, IPaymentBL paymentBL) : base(baseBL)
        {
            _paymentBL = paymentBL;
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi con
        /// </summary>
        /// <returns></returns>
        [HttpGet("Details")]
        public async Task<IActionResult> GetAllDetailsAsync([FromQuery] Guid id, [FromQuery] string? keyword, [FromQuery] int? limit, [FromQuery] int? offset)
        {
            return StatusCode(StatusCodes.Status200OK, await _paymentBL.GetAllDetailsAsync(id, keyword, limit, offset));
        }

        /// <summary>
        /// API xuất khẩu danh sách chứng từ
        /// </summary>
        /// <returns></returns>
        /// Created by: ttanh (02/10/2023)
        [HttpGet("Export")]
        public async Task<IActionResult> ExportToExcelAsync([FromQuery] string? keyword)
        {
            //Lấy dữ liệu cho file excel
            var excelData = await _paymentBL.ExportToExcelAsync(keyword);

            // Context type dành cho file excel
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            // Tạo 1 unique filename cho file excel
            string fileName = $"{typeof(Payment).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            // Trả về file được tự động download khi gọi API
            return File(excelData, Response.ContentType, fileName);
        }

        [HttpPost]
        public override async Task<IActionResult> AddAsync([FromBody] Payment entity)
        {
            return StatusCode(StatusCodes.Status201Created, await _paymentBL.AddAsync(entity));
        }

        [HttpPut]
        public override async Task<IActionResult> UpdateAsync([FromBody] Payment entity)
        {
            return StatusCode(StatusCodes.Status200OK, await _paymentBL.UpdateAsync(entity));
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using MISA.SME2023.BL;
using MISA.SME2023.Common;

namespace MISA.SME2023.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : BaseController<PaymentDetail>
    {
        public PaymentDetailsController(IBaseBL<PaymentDetail> baseBL) : base(baseBL)
        {
        }
    }
}

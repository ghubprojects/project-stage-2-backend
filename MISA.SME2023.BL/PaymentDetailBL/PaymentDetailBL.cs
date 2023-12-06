using MISA.SME2023.Common;
using MISA.SME2023.DL;

namespace MISA.SME2023.BL
{
    public class PaymentDetailBL : BaseBL<PaymentDetail>, IPaymentDetailBL
    {
        public PaymentDetailBL(IBaseDL<PaymentDetail> baseDL) : base(baseDL)
        {
        }
    }
}

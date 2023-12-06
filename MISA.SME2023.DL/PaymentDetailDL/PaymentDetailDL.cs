using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public class PaymentDetailDL : BaseDL<PaymentDetail>, IPaymentDetailDL
    {
        public PaymentDetailDL(DbContext context) : base(context)
        {
        }
    }
}
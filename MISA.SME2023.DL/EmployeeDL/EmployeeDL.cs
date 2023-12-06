using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
        public EmployeeDL(DbContext context) : base(context)
        {
        }
    }
}

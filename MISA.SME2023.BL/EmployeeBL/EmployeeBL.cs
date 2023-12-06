using MISA.SME2023.Common;
using MISA.SME2023.DL;

namespace MISA.SME2023.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        public EmployeeBL(IBaseDL<Employee> baseDL) : base(baseDL)
        {
        }
    }
}

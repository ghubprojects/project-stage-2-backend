using MISA.SME2023.Common;
using MISA.SME2023.DL;

namespace MISA.SME2023.BL
{
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        public DepartmentBL(IBaseDL<Department> baseDL) : base(baseDL)
        {
        }
    }
}

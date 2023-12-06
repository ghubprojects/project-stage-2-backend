using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public class DepartmentDL : BaseDL<Department>, IDepartmentDL
    {
        public DepartmentDL(DbContext context) : base(context)
        {
        }
    }
}

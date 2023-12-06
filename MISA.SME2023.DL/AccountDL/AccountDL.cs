using Dapper;
using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public class AccountDL : BaseDL<Account>, IAccountDL
    {
        private readonly DbContext _context;

        public AccountDL(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<dynamic> GetByNumberAsync(string accountNumber)
        {
            string functionName = $"func_account_get_by_number";
            string query = $"SELECT {_context.SchemaName}.{functionName}(@AccountNumber)";

            var parameters = new DynamicParameters();
            parameters.Add($"@AccountNumber", accountNumber);

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync(query, parameters);
        }

        public async Task<int> GetGradeByIdAsync(Guid accountId)
        {
            string functionName = $"func_account_get_grade_by_id";
            string query = $"SELECT {_context.SchemaName}.{functionName}(@AccountID)";

            var parameters = new DynamicParameters();
            parameters.Add($"@AccountID", accountId);

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
        }

        public async Task UpdateInactiveAsync(Guid id, bool inactive, bool forceChild, string modifiedBy)
        {
            string functionName = $"func_account_update_inactive";
            string query = $"SELECT {_context.SchemaName}.{functionName}(@Id, @Inactive, @ForceChild, @ModifiedBy)";

            var parameters = new DynamicParameters();
            parameters.Add($"@Id", id);
            parameters.Add($"@Inactive", inactive);
            parameters.Add($"@ForceChild", forceChild);
            parameters.Add($"@ModifiedBy", modifiedBy);

            using var connection = _context.CreateConnection();
            await connection.QueryAsync(query, parameters);
        }

        public async Task UpdateIsParentAsync(string parentAccount)
        {
            string functionName = $"func_account_update_is_parent";
            string query = $"SELECT {_context.SchemaName}.{functionName}(@ParentAccount)";

            var parameters = new DynamicParameters();
            parameters.Add($"@ParentAccount", parentAccount);

            using var connection = _context.CreateConnection();
            await connection.QueryAsync(query, parameters);
        }
    }
}

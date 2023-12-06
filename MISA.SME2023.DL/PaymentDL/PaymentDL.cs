using Dapper;
using MISA.SME2023.Common;

namespace MISA.SME2023.DL
{
    public class PaymentDL : BaseDL<Payment>, IPaymentDL
    {
        private readonly DbContext _context;
        public PaymentDL(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllExportAsync(string? keyword)
        {
            string functionName = $"func_payment_get_all_export";
            string dataQuery = $"SELECT * FROM {_context.SchemaName}.{functionName}(@Keyword);";

            var parameters = new DynamicParameters();
            parameters.Add("@Keyword", keyword);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Payment>(dataQuery, parameters);
            return result.ToList();
        }

        public async Task<long> GetTotalAmountSumAsync()
        {
            string functionName = $"func_payment_get_total_amount_sum";
            string dataQuery = $"SELECT * FROM {_context.SchemaName}.{functionName}();";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<long>(dataQuery);
        }

        public async Task<dynamic> GetByNumberAsync(string paymentNumber)
        {
            string functionName = $"func_payment_get_by_number";
            string query = $"SELECT {_context.SchemaName}.{functionName}(@PaymentNumber)";

            var parameters = new DynamicParameters();
            parameters.Add($"@PaymentNumber", paymentNumber);

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync(query, parameters);
        }
    }
}
using Dapper;
using MISA.SME2023.Common;
using Npgsql;
using Z.Dapper.Plus;
using static Dapper.SqlMapper;

namespace MISA.SME2023.DL
{
    public class BaseDL<T> : IBaseDL<T> where T : class
    {
        #region Properties

        private readonly DbContext _context;

        protected NpgsqlTransaction Transaction { get; private set; }
        protected NpgsqlConnection Connection { get => Transaction.Connection; }

        public virtual Type EntityType => typeof(T);
        public virtual string TableName => NameConverter.ConvertPascalToSnakeCase(typeof(T).Name);

        #endregion

        #region Constructors

        public BaseDL(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        #region Get Methods

        public async Task<DataResult<dynamic>> GetAllAsync(string? keyword, int? limit, int? offset)
        {
            string functionName = $"func_{TableName}_get_all";
            string dataQuery = $"SELECT * FROM {_context.SchemaName}.{functionName}(@Keyword, @Limit, @Offset);";
            string totalRecordQuery = $"SELECT count(*) FROM {_context.SchemaName}.{functionName}();";

            var parameters = new DynamicParameters();
            parameters.Add("@Keyword", keyword);
            parameters.Add("@Limit", limit);
            parameters.Add("@Offset", offset);

            using var connection = _context.CreateConnection();
            using var reader = await connection.QueryMultipleAsync(dataQuery + totalRecordQuery, parameters);

            var data = await reader.ReadAsync();
            var totalRecord = await reader.ReadSingleAsync<int>();

            return new(data, totalRecord);
        }

        public async Task<DataResult<dynamic>> GetAllDetailsAsync(Guid id, string? keyword, int? limit, int? offset)
        {
            string functionName = $"func_{TableName}_get_all_details";
            string dataQuery = $"SELECT * FROM {_context.SchemaName}.{functionName}(@Id, @Keyword, @Limit, @Offset);";
            string totalRecordQuery = $"SELECT count(*) FROM {_context.SchemaName}.{functionName}(@Id);";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@Keyword", keyword);
            parameters.Add("@Limit", limit);
            parameters.Add("@Offset", offset);

            using var connection = _context.CreateConnection();
            using var reader = await connection.QueryMultipleAsync(dataQuery + totalRecordQuery, parameters);

            var data = await reader.ReadAsync();
            var totalRecord = await reader.ReadSingleAsync<int>();

            return new(data, totalRecord);
        }

        #endregion

        #region Add Methods

        public async Task<dynamic> GetByIdAsync(Guid id)
        {
            string functionName = $"func_{TableName}_get_by_id";
            string query = $"SELECT * FROM {_context.SchemaName}.{functionName}(@Id);";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync(query, parameters);
        }

        public async Task AddAsync(T entity)
        {
            DapperPlusManager.Entity<T>().Table($"{_context.SchemaName}.{TableName}");
            using var connection = _context.CreateConnection();
            await connection.BulkActionAsync(x => x.BulkInsert(entity));
        }

        public async Task AddMultipleAsync(IEnumerable<T> entities)
        {
            DapperPlusManager.Entity<T>().Table($"{_context.SchemaName}.{TableName}");
            using var connection = _context.CreateConnection();
            await connection.BulkActionAsync(x => x.BulkInsert(entities));
        }

        #endregion

        #region Update Methods

        public async Task UpdateAsync(T entity)
        {
            DapperPlusManager.Entity<T>().Table($"{_context.SchemaName}.{TableName}");
            using var connection = _context.CreateConnection();
            await connection.BulkActionAsync(x => x.BulkUpdate(entity));
        }

        public async Task UpdateMultipleAsync(IEnumerable<T> entities)
        {
            DapperPlusManager.Entity<T>().Table($"{_context.SchemaName}.{TableName}");
            using var connection = _context.CreateConnection();
            await connection.BulkActionAsync(x => x.BulkUpdate(entities));
        }

        #endregion

        #region Delete Methods

        public async Task DeleteAsync(T entity)
        {
            DapperPlusManager.Entity<T>().Table($"{_context.SchemaName}.{TableName}");
            using var connection = _context.CreateConnection();
            await connection.BulkActionAsync(x => x.BulkDelete(entity));
        }

        public async Task DeleteMultipleAsync(IEnumerable<T> entities)
        {
            DapperPlusManager.Entity<T>().Table($"{_context.SchemaName}.{TableName}");
            using var connection = _context.CreateConnection();
            await connection.BulkActionAsync(x => x.BulkDelete(entities));
        }

        #endregion
    }

    #endregion
}

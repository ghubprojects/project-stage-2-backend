using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace MISA.SME2023.DL
{
    public class DbContext
    {
        private readonly DbSettings _dbSettings;
        public string SchemaName { get; set; } = "misa_sme2023";

        public DbContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = $"Host={_dbSettings.Host}; Port={_dbSettings.Port}; Database={_dbSettings.Database}; Username={_dbSettings.UserName}; Password={_dbSettings.Password};";
            return new NpgsqlConnection(connectionString);
        }
    }
}

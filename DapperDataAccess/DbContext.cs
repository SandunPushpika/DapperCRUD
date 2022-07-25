using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DapperDataAccess {
    public class DbContext {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        public DbContext(IConfiguration configuration) { 
            Configuration = configuration;
            connectionString = Configuration.GetConnectionString("sqlConnection");
        }
        public IDbConnection createConnection() {
            return new SqlConnection(connectionString);
        }
    }
}

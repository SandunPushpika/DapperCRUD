using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDataAccess {
    public class DbContext {
        public IDbConnection createConnection() {
            return new SqlConnection("Server=localhost; Database=todoapp; persist security info=True; Integrated Security = SSPI; Encrypt=false;");
        }
    }
}

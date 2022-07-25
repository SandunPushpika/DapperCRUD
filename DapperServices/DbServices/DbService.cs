using DapperDataAccess;
using Dapper;
using System.Data;

namespace DapperServices.DbServices {
    public class DbService : IDbService {

        private readonly IDbConnection _con;

        public DbService(DbContext context) {

            _con = context.createConnection();
        
        }

        public async Task<List<T>> GetObjects<T>(string query) {
            
            var list = await _con.QueryAsync<T>(query);
            return list.ToList();

        }
        public async Task<int> AddObject(string query,object parameter) {

            var id = await _con.QuerySingleAsync<int>(query,parameter);
            return id;
        }
        public async Task DeleteObject(string query, int id) {

            await _con.ExecuteAsync(query,new { id });
         
        }

        public async Task UpdateObject(string query, object parameter) {

            await _con.ExecuteAsync(query,parameter);
        
        }

        public async Task<T> GetObjectById<T>(string query, int id) {

            return await _con.QuerySingleAsync<T>(query, new { id });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServices.DbServices {
    public interface IDbService {
        public Task<List<T>> GetObjects<T>(string query);
        public Task<T> GetObjectById<T>(string query, int id);
        public Task<int> AddObject(string query, object parameter);
        public Task DeleteObject(string query, int id);
        public Task UpdateObject(string query, object parameter);
    }
}

using DapperDataAccess;
using DapperModels;
using Dapper;

namespace DapperServices {
    public class TodoRepository : ITodoRepository {
        private readonly DbContext _context;
        public TodoRepository(DbContext context) {
            _context = context;
        }

        public async Task<Todo> AddNewTodo(Todo todo) {
            String query = "Insert into Todos (Title,Description,UserId) VALUES (@Title,@Description,@UserId)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var con = _context.createConnection()) {
                int id = await con.QuerySingleAsync<int>(query,todo);
                todo.Id = id;

                return todo;
            }
        }

        public async Task DeleteTodo(int id) {
            using (var con = _context.createConnection()) {
                await con.ExecuteAsync("Delete from todos where Id=@id",new { id });
            }
        }

        public async Task<List<Todo>> GetAllTodos() {
            String query = "Select * from Todos";

            using (var con = _context.createConnection()) {
                var companies = await con.QueryAsync<Todo>(query);
                return companies.ToList();
            }
        }

        public async Task<Todo> GetTodoById(int id) {
            using (var con = _context.createConnection()) {
                return await con.QuerySingleAsync<Todo>("select * from todos where Id=@id",new { id });
            }
        }

        public async Task UpdateTodo(int id, Todo todo) {

            string query = "UPDATE todos SET Title=@title, Description=@description, UserId=@userid where Id=@id";

            todo.Id = id;

            using (var con = _context.createConnection()) {
                await con.ExecuteAsync(query, todo);
            }
        }
    }
}

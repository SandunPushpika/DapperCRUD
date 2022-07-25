using DapperModels;
using DapperServices.DbServices;

namespace DapperServices.TodoServices {
    public class TodoRepository : ITodoRepository {

        private readonly IDbService _service;
        public TodoRepository(IDbService service) {
            _service = service;
        }

        public async Task<Todo> AddNewTodo(Todo todo) {
            
            string query = "Insert into Todos (Title,Description,UserId) VALUES (@Title,@Description,@UserId)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _service.AddObject(query, todo);

            return await _service.GetObjectById<Todo>("Select * from Todos where Id=@id", id);

        }

        public async Task DeleteTodo(int id) {
            await _service.DeleteObject("Delete from todos where Id=@id", id);
        }

        public async Task<List<Todo>> GetAllTodos() {
            
            string query = "Select * from Todos";
            return await _service.GetObjects<Todo>(query);

        }

        public async Task<Todo> GetTodoById(int id) {

            return await _service.GetObjectById<Todo>("select * from todos where Id=@id", id);

        }

        public async Task UpdateTodo(int id, Todo todo) {

            string query = "UPDATE todos SET Title=@title, Description=@description, UserId=@userid where Id=@id";
            todo.Id = id;

            await _service.UpdateObject(query, todo);
        }
    }
}

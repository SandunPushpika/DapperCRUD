using DapperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServices.TodoServices {
    public interface ITodoRepository {
        public Task<Todo> AddNewTodo(Todo todo);
        public Task UpdateTodo(int id, Todo todo);
        public Task<List<Todo>> GetAllTodos();
        public Task<Todo> GetTodoById(int id);
        public Task DeleteTodo(int id);
    }

}

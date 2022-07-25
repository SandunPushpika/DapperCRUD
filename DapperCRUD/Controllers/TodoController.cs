using DapperModels;
using DapperServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers {
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase{
        private readonly ITodoRepository _service;
        public TodoController(ITodoRepository service) { 
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTodos() {
            var todos = await _service.GetAllTodos();
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTodo(Todo todo) {
            var created_todo = await _service.AddNewTodo(todo);
            return CreatedAtRoute("/createdtodo", created_todo.Id, created_todo);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTodo(int id) { 
            await _service.DeleteTodo(id);
            return NoContent();
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo todo) {
            await _service.UpdateTodo(id, todo);
            return NoContent();
        }
    }
}

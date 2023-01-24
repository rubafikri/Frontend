using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : Controller
    {
        private readonly IToDo _toDo;

        public ToDoController(IToDo toDo)
        {
            _toDo = toDo;
        }

        [HttpGet("/Getall")]
        [Produces("application/json")]

        public async Task<IActionResult> Get()
        {
            return Ok(await _toDo.GetAllToDos());
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ToDo>> Get(int id)
        {

            var todo = await _toDo.GetById(id);
            if (todo == null)
                return NotFound();
            else
                return Ok(todo);
        }

        [HttpPost("/addpost")]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] ToDo todo)
        {
            
            var todoResult = await _toDo.Add(new ToDo
            {
                Task = todo.Task,
                Description = todo.Description,
                DueDate = todo.DueDate,
                IsCompleted = todo.IsCompleted,
                ToDoCategoryId = todo.ToDoCategoryId
            });
            
            return CreatedAtAction(nameof(Get), new { id = todoResult.Id }, todoResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ToDo todo)
        {
            var result = await _toDo.Update(id, todo);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _toDo.Delete(id);
            if (result == true)
                return Ok("ToDo has been Deleted");
            else
                return BadRequest();
        }

    }
}

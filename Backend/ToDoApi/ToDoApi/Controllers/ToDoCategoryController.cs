using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/cat")]
    [ApiController]
    public class ToDoCategoryController : ControllerBase
    {
        private readonly ITodCatergory _toDo;

        public ToDoCategoryController(ITodCatergory toDo)
        {
            _toDo = toDo;
        }

        [HttpGet("/GetallCatergories")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _toDo.GetAllToDosCategory());
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ToDoCategory>> Get(int id)
        {

            var todo = await _toDo.GetById(id);
            if (todo == null)
                return NotFound();
            else
                return Ok(todo);
        }

        [HttpPost("addpost")]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] ToDoCategory todo)
        {
            var todoResult = await _toDo.Add(new ToDoCategory
            {
                Name = todo.Name
            });
            return CreatedAtAction(nameof(Get), new { id = todoResult.Id }, todoResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ToDoCategory todo)
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

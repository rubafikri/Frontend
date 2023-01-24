using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class ToDoReposeitery : IToDo
    {
        private readonly ToDoDbContext _context;

        public ToDoReposeitery(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<ToDo> Add(ToDo todo)
        {
            await _context.toDos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> Delete(int id)
        {
            var todo = await _context.toDos.FindAsync(id);
            if (todo == null)
                return false;
            else
            {
                _context.toDos.Remove(todo);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<ToDo>> GetAllToDos()
        {
            return await _context.toDos.ToListAsync();
        }

        public async Task<ToDo> GetById(int id)
        {
            var todo = await _context.toDos.FindAsync(id);
            return todo;
        }

        public async Task<ToDo> Update(int id, ToDo todoChanegs)
        {
            var todo = await _context.toDos.FindAsync(id);
            if (todo == null)
                return todo;
            else
            {
                todo.Task = todoChanegs.Task;
                todo.DueDate = todoChanegs.DueDate;
                todo.Description = todoChanegs.Description;
                todo.IsCompleted = todoChanegs.IsCompleted;
                todo.ToDoCategoryId = todoChanegs.ToDoCategoryId;
                await _context.SaveChangesAsync();
                return todo;
            }
        }
    }
}

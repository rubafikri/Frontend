using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class TodoCategoryRepo : ITodCatergory
    {
        private readonly ToDoDbContext _context;

        public TodoCategoryRepo(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<ToDoCategory> Add(ToDoCategory todo)
        {
            await _context.toDoCategories.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> Delete(int id)
        {
            var todo = await _context.toDoCategories.FindAsync(id);
            if (todo == null)
                return false;
            else
            {
                _context.toDoCategories.Remove(todo);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<ToDoCategory>> GetAllToDosCategory()
        {
            return await _context.toDoCategories.ToListAsync();
        }

        public async Task<ToDoCategory> GetById(int id)
        {
            var todo = await _context.toDoCategories.FindAsync(id);
            return todo;
        }

        public async Task<ToDoCategory> Update(int id, ToDoCategory todoChanegs)
        {
            var todo = await _context.toDoCategories.FindAsync(id);
            if (todo == null)
                return todo;
            else
            {
                todo.Name = todoChanegs.Name;
                await _context.SaveChangesAsync();
                return todo;
            }
        }
    }
}

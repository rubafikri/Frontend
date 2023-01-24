using BookStore.API.Data;
using BookStore.API.Interface;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context)
        {
            _context = context;

        }

        public async Task<Categories> Create(Categories categories)
        {
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();
            return categories;
        }

        public async Task<bool> Delete(int id)
        {
            var Categories = await _context.Categories.FindAsync(id);
            if (Categories == null)
                return false;
            else
            {
                _context.Categories.Remove(Categories);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Categories>> GetAll()
        {
            var Categories = await _context.Categories.ToListAsync();
            return Categories;
        }

        public async Task<Categories> Update(Categories categories)
        {
            var categoriesFound = await _context.Categories.FindAsync(categories.Id);
            if (categoriesFound == null)
            {
                return categoriesFound;
            }
            else
            {
                categoriesFound.Name = categories.Name;
                _context.Categories.Update(categoriesFound);
                await _context.SaveChangesAsync();
                return categoriesFound;
            }
        }
    }
}

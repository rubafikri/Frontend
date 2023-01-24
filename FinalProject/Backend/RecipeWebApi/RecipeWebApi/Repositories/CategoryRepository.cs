using Mapster;
using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Data;
using RecipeWebApi.DTOs;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Models;

namespace RecipeWebApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RecipesDbContext _context;
        public CategoryRepository(RecipesDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Add(CategoryDto Category)
        {
            var categorynew = Category.Adapt<Category>();
            await _context.categories.AddAsync(categorynew);
            await _context.SaveChangesAsync();
            return categorynew;
        }

        public async Task<bool> Delete(string Id)
        {
            var category = await _context.categories.FindAsync(Id);
            if (category == null)
                return false;
            else
            {
                _context.categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
             return await _context.categories.ProjectToType<CategoryDto>().ToListAsync();
        }

        public async Task<Category> GetById(string Id)
        {
            var category = await _context.categories.Include(x => x.Recipes).ToListAsync();
            var recipeNew = category.Where(x => x.CategoryId == Id).FirstOrDefault();
            return recipeNew;
        }

        public async Task<Category> Update(string Id, CategoryDto CategoryChanegs)
        {
            var category = await _context.categories.FindAsync(Id);
            if (category == null)
                return category;
            else
            {
                category = CategoryChanegs.Adapt<Category>();

                await _context.SaveChangesAsync();
                return category;
            }
        }
    }
}

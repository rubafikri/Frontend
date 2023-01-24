using Mapster;
using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Data;
using RecipeWebApi.DTOs;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Models;

namespace RecipeWebApi.Repositories
{
    public class RecipeRepositery : IRecipeRepository
    {
        private readonly RecipesDbContext _context;
        public RecipeRepositery(RecipesDbContext context)
        {
            _context = context;
        }
       public async Task<Recipe> Add(RecipeDto Recipe)
        {
            var uploadFolder = Path.Combine("wwwroot/", "Photos");
            string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(path: Recipe.photoFile.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueName);
            Recipe.photoFile.CopyTo(new FileStream(filePath, FileMode.Create));
            Recipe.PhotoName = uniqueName;
            var recipe = Recipe.Adapt<Recipe>();
            await _context.recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<bool> Delete(string Id)
        {
            var recipe = await _context.recipes.FindAsync(Id);
            if (recipe == null)
                return false;
            else
            {
                _context.recipes.Remove(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _context.recipes.ToListAsync();

        }

        public async Task<Recipe> GetById(string Id)
        {
            var recipe = await _context.recipes.Include(x => x.Comments).ToListAsync();
            var recipeNew =  recipe.Where(x => x.Id == Id).First();
            return recipeNew;
        }

        public async Task<Recipe> Update(string Id, RecipeDto RecipeChanegs)
        {
            var recipe = await _context.recipes.FindAsync(Id);
            if (recipe == null)
                return recipe;
            else
            {
                recipe = RecipeChanegs.Adapt<Recipe>();
                await _context.SaveChangesAsync();
                return recipe;
            }
        }

        }
}

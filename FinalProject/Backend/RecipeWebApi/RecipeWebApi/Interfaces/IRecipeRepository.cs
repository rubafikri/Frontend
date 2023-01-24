using RecipeWebApi.DTOs;
using RecipeWebApi.Models;

namespace RecipeWebApi.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe> GetById(string Id);
        Task<Recipe> Add(RecipeDto Recipe);
        Task<Recipe> Update(string Id, RecipeDto RecipeChanegs);
        Task<bool> Delete(string Id);

    }
}

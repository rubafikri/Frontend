using RecipeWebApi.DTOs;
using RecipeWebApi.Models;

namespace RecipeWebApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<Category> GetById(string Id);
        Task<Category> Add(CategoryDto Category);
        Task<Category> Update(string Id, CategoryDto CategoryChanegs);
        Task<bool> Delete(string Id);
    }
}

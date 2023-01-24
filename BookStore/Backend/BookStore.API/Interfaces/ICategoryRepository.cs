using BookStore.API.Models;

namespace BookStore.API.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Categories>> GetAll();
        Task<Categories> Create(Categories categories);
        Task<Categories> Update(Categories categories);
        Task<bool> Delete(int id);
    }
}

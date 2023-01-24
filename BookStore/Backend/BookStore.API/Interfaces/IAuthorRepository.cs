using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Authors>> GetAll();
        Task<Authors> Create(Authors authors);
        Task<Authors> Update(Authors authors);
        Task<bool> Delete(int id);


    }
}

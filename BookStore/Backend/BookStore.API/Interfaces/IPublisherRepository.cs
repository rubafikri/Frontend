using BookStore.API.DTOs;
using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IPublisherRepository
    {
        Task<List<Publishers>> GetAll(string? searchKey);
        Task<Publishers> GetById(int id);
        Task<Publishers> Create(Publishers publishers);
        Task<Publishers> Update(Publishers publishers);
        Task<bool> Delete(int id);

    }
}

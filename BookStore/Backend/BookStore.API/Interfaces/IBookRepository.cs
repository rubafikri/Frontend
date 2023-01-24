using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Interface
{
    public interface IBookRepository
    {
        Task<Books> GetById(int id);
        Task<List<Books>> GetAll(string? searchKey);
        Task<Books> Create([FromForm] Books book);
        Task<Books> Update(Books book);
        Task<bool> Delete(int id);
        Task<List<Books>> GetAllByCategory(int categoryId);
    }
}

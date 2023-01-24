using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IStaticPageRepository
    {
        Task<List<StaticPages>> GetAll(string? PageName);
        Task<StaticPages> Create(StaticPages staticPages);
        Task<StaticPages> Update(StaticPages staticPages);
        Task<bool> Delete(int id);
       

    }
}

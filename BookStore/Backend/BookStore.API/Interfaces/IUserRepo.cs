using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IUserRepo
    {
        Task<AppUser> GetAll(string id);
    }
}

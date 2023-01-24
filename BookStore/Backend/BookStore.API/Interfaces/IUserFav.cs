using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IUserFav
    {
        Task<List<UserFavorite>> GetAll();
        Task<UserFavorite> Create(UserFavorite userFavorite);
        Task<bool> Delete(int id);

    }
}

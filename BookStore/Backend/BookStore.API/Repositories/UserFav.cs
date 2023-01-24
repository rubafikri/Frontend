using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.API.Repositories
{
    public class UserFav : IUserFav
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public UserFav(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
        public async Task<UserFavorite> Create(UserFavorite userFavorite)
        {
            await _bookStoreDbContext.UserFavs.AddAsync(userFavorite);
            await _bookStoreDbContext.SaveChangesAsync();
            return userFavorite;

        }

        public async Task<bool> Delete(int id)
        {
          
            var listfav =  _bookStoreDbContext.UserFavs.Where(x => x.BookId == id).FirstOrDefault();



            if (listfav == null)
                return false;
            else
            {
                _bookStoreDbContext.UserFavs.Remove(listfav);
                await _bookStoreDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<UserFavorite>> GetAll()
        {
            return await _bookStoreDbContext.UserFavs.ToListAsync();
        }
    }
}

using BookStore.API.Data;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly BookStoreDbContext _context;
        private readonly IUserRepo _userRepo;
        private readonly UserManager<AppUser> _userManager;

        public UserRepo(BookStoreDbContext context , IUserRepo userRepo , UserManager<AppUser> userManager)
        {
            _context = context;
            _userRepo = userRepo;
            _userManager = userManager;

        }
        public async Task<AppUser> GetAll(string id)
        {
            var userExists = await _userManager.FindByIdAsync(id);
            return userExists;
        }
    }
}

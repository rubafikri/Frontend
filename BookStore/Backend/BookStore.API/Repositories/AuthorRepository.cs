using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Authors> Create(Authors authors)
        {
            await _context.Authors.AddAsync(authors);
            await _context.SaveChangesAsync();
            return authors;
        }

        public async Task<bool> Delete(int id)
        {
            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
                return false;
            else
            {
                _context.Authors.Remove(authors);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Authors>> GetAll()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Authors> Update(Authors authors)
        {

            var authorsFound = await _context.Authors.FindAsync(authors.Id);

            if (authorsFound == null)
            {
                return authorsFound;
            }
            else
            {
                authorsFound.Name = authors.Name;
                _context.Authors.Update(authorsFound);
                await _context.SaveChangesAsync();
                return authorsFound;
            }
        }
    }
}

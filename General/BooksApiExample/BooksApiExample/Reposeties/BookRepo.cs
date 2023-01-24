using BooksApiExample.Data;
using BooksApiExample.DTOs;
using BooksApiExample.Interfaces;
using BooksApiExample.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BooksApiExample.Reposeties
{
    public class BookRepo : IBookRepo

    {
        private readonly BookDbContext _dbContext;
        public BookRepo(BookDbContext _context)
        {
            _dbContext = _context;
        }


        public async Task<Book> Add(Book book)
        {
          await _dbContext.books.AddAsync(book);
           await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<List<BookDto>> getAll()
        {
          return await  _dbContext.books.ProjectToType<BookDto>().ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _dbContext.books.FindAsync(id);
            //if (book == null)
            //    return false;
            return book;
        }

    }
}

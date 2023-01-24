using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Models;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IImageUploaderService _imageUploaderService;

        public BookRepository(BookStoreDbContext context , IImageUploaderService imageUploaderService)
        {
            _context = context;
            _imageUploaderService = imageUploaderService;
        }

        public async Task<Books> Create([FromForm] Books book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;

        }

        public async Task<bool> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<List<Books>> GetAll(string? searchKey)
        {
            var books = await _context.Books.
                Include(x => x.Translator)
               .Include(x => x.Category)
               .Include(x => x.Author)
               .Include(x => x.Publisher)
               .ToListAsync();
            books = await _context.Books.
            Where(x => x.Name.Contains(searchKey)
            || x.Author.Name.Contains(searchKey) 
            || string.IsNullOrEmpty(searchKey)).ToListAsync();
            return books;

              }

        public async Task<List<Books>> GetAllByCategory(int categoryId)
        {
            var book = await _context.Books
               .Where(x => x.CategoryId == categoryId)
               .ToListAsync();
            return book;
        }

        public async Task<Books> GetById(int id)
        {
            var book = await _context.Books.Include(x => x.Translator)
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Include(x => x.Publisher).ToListAsync();
            var bookFound = book.Find(book => book.Id == id);
            return bookFound;
        }

        public async Task<Books> Update(Books book)
        {
            var bookFound = await _context.Books.SingleOrDefaultAsync(x => x.Id == book.Id);

            if (bookFound == null)
                throw new ArgumentException("Item Not Found");
            else
            {
                bookFound.About = book.About;
                bookFound.Name = book.Name;
                bookFound.PublishYear = book.PublishYear;
                bookFound.Price = book.Price;
                bookFound.Discount = book.Discount;
                bookFound.Image = book.Image;
                _context.Books.Update(bookFound);
                await _context.SaveChangesAsync();
                return bookFound;

            }
        }
    }
    }

using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookSuggestionRepository : IBookSuggestionRepository
    {
        private readonly BookStoreDbContext _context;

        public BookSuggestionRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<BookSuggestion> Create(BookSuggestion bookSuggestion)
        {
            await _context.BookSuggestions.AddAsync(bookSuggestion);
            await _context.SaveChangesAsync();
            return bookSuggestion;  
        }

        public async Task<bool> Delete(int id)
        {

            var bookSuggestions = await _context.BookSuggestions.FindAsync(id);
            if (bookSuggestions == null)
                return false;
            else
            {
                _context.BookSuggestions.Remove(bookSuggestions);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<BookSuggestion>> GetAll()
        {
            var bookSuggestions = await _context.BookSuggestions.ToListAsync();
            return bookSuggestions;
        }

        public async Task<BookSuggestion> Update(BookSuggestion bookSuggestion)
        {
            var bookSuggestionsFound = await _context.BookSuggestions.FindAsync(bookSuggestion.Id) ;
            if (bookSuggestionsFound == null)
            {
                return bookSuggestionsFound;
            }
            else
            {
                bookSuggestionsFound.AuthorName = bookSuggestion.AuthorName;
                bookSuggestionsFound.PublisherName = bookSuggestion.PublisherName;
                bookSuggestionsFound.Notes = bookSuggestion.Notes;
                bookSuggestionsFound.Email = bookSuggestion.Email;
                bookSuggestionsFound.BookName = bookSuggestion.BookName;
                _context.BookSuggestions.Update(bookSuggestionsFound);
                await _context.SaveChangesAsync();
                return bookSuggestionsFound;
            }
        }
        public async Task<bool> isRead(int id)
        {
            var bookSuggestions = await _context.BookSuggestions.FindAsync(id);
            if (bookSuggestions == null)
                return false;
            else
            {
                if (bookSuggestions.ReadAt == null)
                {

                    bookSuggestions.ReadAt = DateTime.Now;

                    _context.BookSuggestions.Update(bookSuggestions);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return true;

            }

        }
    }
}

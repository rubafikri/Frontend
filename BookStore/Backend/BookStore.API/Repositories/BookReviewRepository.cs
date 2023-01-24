using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookStore.API.Repositories
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly BookStoreDbContext _context;


        public BookReviewRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<BookReview> Create(BookReview bookReview)
        {
            await _context.BookReviews.AddAsync(bookReview);
            await _context.SaveChangesAsync();
            return bookReview;
        }

        public async Task<bool> Delete(int id)
        {
            var bookReview = await _context.BookReviews.FindAsync(id);
            if (bookReview == null)
                return false;
            else
            {
                _context.BookReviews.Remove(bookReview);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<int> GetBookRating(int bookId)
        {
           var bookRatings =  _context.BookReviews.Where(x => x.BookId == bookId && x.Rate != 0 );
            if (bookRatings.Count() != 0)
            {
                var Bookrating = await bookRatings.AverageAsync(bookRate => bookRate.Rate);
                return ((int)Bookrating);

            }
            else
            {
                return 0;
            }
          

        }

        public async Task<BookReview> Update(BookReview bookReview)
        {
            var bookReviewFound = await _context.BookReviews.SingleOrDefaultAsync(x => x.Id == bookReview.Id);
            if (bookReviewFound == null)
            {
                return bookReviewFound;
            }
            else
            {
                bookReviewFound.Comment = bookReview.Comment;
                bookReviewFound.Rate = bookReview.Rate;
                _context.BookReviews.Update(bookReviewFound);
                await _context.SaveChangesAsync();
                return bookReviewFound;
            }
        }

        public async Task<List<BookReview>> GetAll()
        {
            return await _context.BookReviews.ToListAsync();
        }
    }
}

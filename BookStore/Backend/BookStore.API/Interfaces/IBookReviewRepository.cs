using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IBookReviewRepository
    {
        Task<BookReview> Create(BookReview bookReview);
        Task<int> GetBookRating(int bookId);
        Task<bool> Delete(int id);
        Task<BookReview> Update(BookReview bookReview);
        Task<List<BookReview>> GetAll();

    }
}

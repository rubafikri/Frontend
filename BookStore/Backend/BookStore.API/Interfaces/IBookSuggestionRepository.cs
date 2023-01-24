using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IBookSuggestionRepository
    {
        Task<List<BookSuggestion>> GetAll();
        Task<BookSuggestion> Create(BookSuggestion bookSuggestion);
        Task<BookSuggestion> Update(BookSuggestion bookSuggestion);
        Task<bool> Delete(int id);
        public Task<bool> isRead(int id);


    }
}

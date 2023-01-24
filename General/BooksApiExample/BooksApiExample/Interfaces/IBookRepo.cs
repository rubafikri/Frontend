using BooksApiExample.DTOs;
using BooksApiExample.Models;

namespace BooksApiExample.Interfaces
{
    public interface IBookRepo
    {
        Task<List<BookDto>> getAll();

        Task<Book> Add(Book book);
        Task<Book> GetById(int id);

    }
}

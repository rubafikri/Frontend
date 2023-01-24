using BooksApiExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksApiExample.Data
{
    public class BookDbContext : IdentityDbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> books { get; set; }
    }
}

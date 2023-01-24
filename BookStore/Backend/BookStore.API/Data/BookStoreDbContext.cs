using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreDbContext : IdentityDbContext<AppUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
              .HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<UserFavorite>().HasKey(x => new { x.AppUserId, x.BookId });
        }


        public DbSet<Books> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BookSuggestion> BookSuggestions { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ContactUs> ContantUs { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<StaticPages> StaticPages { get; set; }
        public DbSet<Translators> Translators { get; set; }
        public DbSet<UserFavorite> UserFavs { get; set; }
        public DbSet<Zone> Zones { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Models;
using System.Reflection.Emit;
using System.Security.Claims;

namespace RecipeWebApi.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        { 
            modelBuilder.Entity<Comments>().HasKey(x => new { x.UsersId, x.RecipesId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> users { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}

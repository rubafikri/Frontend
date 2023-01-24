using Microsoft.EntityFrameworkCore;
using PortofiloProject.Models;

namespace PortofiloProject.Data
{
    public class PortfoiloDbContext : DbContext
    {
        public PortfoiloDbContext(DbContextOptions<PortfoiloDbContext> options) : base(options)
        {

        }

        public DbSet<Project> projects { get; set; }
        public DbSet<Post> posts { get; set; }
    }
}

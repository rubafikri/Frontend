using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;


namespace ToDoApi.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoCategory>().HasData(
                new ToDoCategory { Id = 1, Name = "Complete" },
                new ToDoCategory { Id = 2, Name = "Imprtant" }
                );

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo { Id = 1, Task = "Task 1" , ToDoCategoryId = 1, IsCompleted = true , Description = "Task 1 HAs completed" ,DueDate = DateTime.Now },
                new ToDo { Id = 2, Task = "Task 2", ToDoCategoryId = 2, IsCompleted = false, Description = "Task 2 HAs completed", DueDate = DateTime.Now }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ToDo> toDos { get; set; }
       public DbSet<ToDoCategory> toDoCategories { get; set; }
    }
}

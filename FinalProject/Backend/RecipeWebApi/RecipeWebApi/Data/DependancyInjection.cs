using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Repositories;

namespace RecipeWebApi.Data
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<RecipesDbContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IRecipeRepository, RecipeRepositery>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentReposetory, CommentRepository>();

            return services;
        }
    }
}

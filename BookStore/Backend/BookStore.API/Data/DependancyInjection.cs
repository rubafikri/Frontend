using BookStore.API.Data;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RecipeWebApi.Data
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped< ICategoryRepository, CategoryRepository>();
            services.AddScoped< IAuthorRepository, AuthorRepository>();
            services.AddScoped< IZoneRepository, ZoneRepository>();
            services.AddScoped< IPublisherRepository, PublisherRepository>();
            services.AddScoped< IContantUsRepository, ContantUsRepository>();
            services.AddScoped< ITranslatorRepository, TranslatorRepository>();
            services.AddScoped< IBookRepository, BookRepository>();
            services.AddScoped< IBookSuggestionRepository, BookSuggestionRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IStaticPageRepository, StaticPageRepository>();
            services.AddScoped<IBookReviewRepository, BookReviewRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUserFav, UserFav>();


            services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<BookStoreDbContext>()
               .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddAuthLayer(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(options => options.TokenValidationParameters =
               new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = configuration["JWT:ValidAudience"],
                   ValidIssuer = configuration["JWT:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secert"])),
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
               });
            return services;
        }
    }
}

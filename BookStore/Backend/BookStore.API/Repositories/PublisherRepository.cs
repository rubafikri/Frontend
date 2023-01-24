using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Extensions;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IImageUploaderService _imageUploaderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PublisherRepository(BookStoreDbContext context , IImageUploaderService imageUploaderService , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _imageUploaderService = imageUploaderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Publishers> Create(Publishers publishers)
        {
           await  _context.Publishers.AddAsync(publishers);
           await _context.SaveChangesAsync();
           return publishers;

        }

        public async Task<bool> Delete(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
                return false;
            else
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

        public async Task<List<Publishers>> GetAll(string? searchKey)
        {
            //var queryable = _context.Publishers.AsQueryable();

            // 1 select count(*) from publihsers => total count of rows;
            //await _httpContextAccessor.HttpContext.InsertParametersPaginationHeaders(queryable);
            //return await queryable.OrderBy(x => x.Name).Paginate(paginationDTO).ToListAsync();


            var publishers = await _context.Publishers.Where(x => x.Name.Contains(searchKey)
           || string.IsNullOrEmpty(searchKey)).Select(x => new Publishers()
           {
               Id = x.Id,
               Name = x.Name,
               Logo = x.Logo,
           }).ToListAsync();
            return publishers;
        }

        public async Task<Publishers> GetById(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            return publisher;
        }

        public async Task<Publishers> Update(Publishers publishers)
        {
            var publisher = await _context.Publishers.SingleOrDefaultAsync(x => x.Id == publishers.Id);

            if (publisher == null)
                return publisher;
            else
            {
                publisher.Logo = publishers.Logo;
                publisher.Name = publishers.Name;
                _context.Publishers.Update(publisher);
                await _context.SaveChangesAsync();
                return publisher;

            }
        }
    }
}

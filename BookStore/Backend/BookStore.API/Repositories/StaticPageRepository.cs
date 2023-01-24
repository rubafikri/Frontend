using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class StaticPageRepository : IStaticPageRepository
    {
        private readonly BookStoreDbContext _context;

        public StaticPageRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<StaticPages>> GetAll(string? PageName)
        {
            var staticPages = await _context.StaticPages.Where(x => x.PageName == PageName || string.IsNullOrEmpty(PageName)).ToListAsync();
            return staticPages;
        }

        public async Task<StaticPages> Create(StaticPages staticPages)
        {
            await _context.StaticPages.AddAsync(staticPages);
            await _context.SaveChangesAsync();
            return staticPages;
        }

        public async Task<StaticPages> Update(StaticPages staticPages)
        {
            var staticPage = await _context.StaticPages.SingleOrDefaultAsync(x => x.Id == staticPages.Id);

            if (staticPage == null)
                return staticPages;
            else
            {

                staticPage.PageName = staticPages.PageName;
                staticPage.Details = staticPages.Details;
                _context.StaticPages.Update(staticPage);
                await _context.SaveChangesAsync();
                return staticPage;

            }
           
        }

        public async Task<bool> Delete(int id)
        {
            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage == null)
                return false;
            else
            {
                _context.StaticPages.Remove(staticPage);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}

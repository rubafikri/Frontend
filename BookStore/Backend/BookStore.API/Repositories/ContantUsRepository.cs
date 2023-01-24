using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ContantUsRepository : IContantUsRepository
    {
        private readonly BookStoreDbContext _context;

        public ContantUsRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ContactUs> Create(ContactUs contactUs)
        {
            await _context.ContantUs.AddAsync(contactUs);
            await _context.SaveChangesAsync();
            return contactUs;
        }

        public async Task<bool> Delete(int id)
        {
            var contactUs = await _context.ContantUs.FindAsync(id);
            if (contactUs == null)
                return false;
            else
            {
                _context.ContantUs.Remove(contactUs);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async  Task<List<ContactUs>> GetAll()
        {
            var contactUs = await _context.ContantUs.ToListAsync();
            return contactUs;
        }

        public async Task<ContactUs> Update(ContactUs contactUs)
        {
            var contactUsFound = await _context.ContantUs.FindAsync(contactUs.Id);
            if (contactUsFound == null)
            {
                return contactUsFound;
            }
            else
            {
                contactUsFound.Email = contactUs.Email;
                contactUsFound.Message = contactUs.Message;
                contactUsFound.FullName = contactUs.FullName;
               
                _context.ContantUs.Update(contactUsFound);
                await _context.SaveChangesAsync();
                return contactUsFound;
            }
        }

    }
}

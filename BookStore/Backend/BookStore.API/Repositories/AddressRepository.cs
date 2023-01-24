using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BookStoreDbContext _context;
        public AddressRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Create(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<bool> Delete(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
                return false;
            else
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Address>> GetAll()
        {
            var address = await _context.Addresses.Include(x => x.Zone).ToListAsync();
            return address;
        }

        public async Task<Address> Update(Address address)
        {
            var addressFound = await _context.Addresses.FindAsync(address.Id);
            if (addressFound == null)
            {
                return new Address { Id = 1 , Address1 = "dwedwqdwq" , Address2 = "efwedqwdqwd" , PostalCode=  "5fed" , ZoneId= 1};
            }
            else
            {
                addressFound.Address1 = address.Address1;
                addressFound.Address2 = address.Address2;
                addressFound.ZoneId = address.ZoneId;
                address.PostalCode = address.PostalCode;
                _context.Addresses.Update(addressFound);
                await _context.SaveChangesAsync();
                return addressFound;
            }

        }

    }
}

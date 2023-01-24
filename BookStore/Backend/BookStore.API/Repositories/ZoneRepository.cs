using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly BookStoreDbContext _context;
        public ZoneRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Zone>> GetAll()
        {
            var zones = await _context.Zones.ToListAsync();
            return zones;
        }
        public async Task<Zone> Create(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();
            return zone;
        }
        public async Task<Zone> Update(Zone zone)
        {
            var zoneFound = await _context.Zones.SingleOrDefaultAsync(x => x.Id == zone.Id);

            if (zoneFound == null)
                return zoneFound;
            else
            {
                zoneFound.Name = zone.Name;
                _context.Zones.Update(zoneFound);
                await _context.SaveChangesAsync();
                return zoneFound;

            }
        }
        public async Task<bool> Delete(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            if (zone == null)
                return false;
            else
            {
                _context.Zones.Remove(zone);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}

using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IZoneRepository
    {
        Task<List<Zone>> GetAll();
        Task<Zone> Create(Zone zone);
        Task<Zone> Update(Zone zone);
        Task<bool> Delete(int id);
    }
}

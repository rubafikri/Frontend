using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAll();
        Task<Address> Create(Address address);
        Task<Address> Update(Address address);
        Task<bool> Delete(int id);
      
    }
}

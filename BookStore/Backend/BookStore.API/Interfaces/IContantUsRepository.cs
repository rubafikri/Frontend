using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IContantUsRepository
    {
        Task<List<ContactUs>> GetAll();
        Task<ContactUs> Create(ContactUs contactUs);
        Task<ContactUs> Update(ContactUs contactUs);
        Task<bool> Delete(int id);
        
    }
}

using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sales>> GetSaleByUserId(string appUserId);
        Task<List<Sales>> GetAll();
        public Task<bool> isSold(int id);
        Task<Sales> Create(Sales sales);
        Task<bool> Delete(int id);
    }
}

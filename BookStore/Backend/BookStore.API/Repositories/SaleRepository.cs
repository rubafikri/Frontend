using BookStore.API.Data;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IBookRepository _bookRepository;


        public SaleRepository(BookStoreDbContext context , IBookRepository bookRepository)
        { 
            _context = context;
            _bookRepository = bookRepository;
        }
        public async Task<List<Sales>> GetSaleByUserId(string appUserId)
        {
            var sales = await _context.Sales.Include(x=>x.Book).Include(x=>x.AppUser).Where(x=> x.AppUserId == appUserId).ToListAsync();
            return sales;
        }

        public async Task<List<Sales>> GetAll()
        {
            var sales = await _context.Sales.Include(x => x.Book).Include(x => x.AppUser).ToListAsync();
            return sales;
        }
        public async Task<Sales> Create(Sales sale)
        {
            var bookDetials = await _bookRepository.GetById(sale.BookId);
            if(bookDetials != null)
            {
                var saleNew = new Sales()
                {
                    Amount = bookDetials.Price,
                    BookId = sale.BookId,
                    AppUserId = sale.AppUserId,
                    TotalPrice = sale.Amount
                };
                await _context.Sales.AddAsync(sale);
                await _context.SaveChangesAsync();
                return saleNew;
            }
            else
            {
                return sale;
            }
          
        }
       

        public async Task<bool> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return false;
            else
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
                return true;
            }

        }


        public async Task<bool> isSold(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return false;
            else
            {
                if (sale.IsSold == IsSoldStatus.notOk)
                {
                    sale.IsSold = IsSoldStatus.ok;
                    sale.SoldDate = DateTime.Now;
                    _context.Sales.Update(sale);
                    await _context.SaveChangesAsync();
                    return true;
                }
            
            }
            return true;

        }
    }
}

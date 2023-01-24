using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.API.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly UserManager<AppUser> _userManager;

        public SaleController(ISaleRepository saleRepository, UserManager<AppUser> userManager)
        {
            _saleRepository = saleRepository;
            _userManager = userManager;
        }
        [HttpGet("{appUserId}")]
        public async Task<IActionResult> GetAllByUserId(string appUserId)
        {
            var sales = await _saleRepository.GetSaleByUserId(appUserId);
            return Ok(sales);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll( )
        {

            var sales = await _saleRepository.GetAll();
            return Ok(sales);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateSalesDto createSalesDto)
        {
            var newSales = createSalesDto.Adapt<Sales>();
            var sale = await _saleRepository.Create(newSales);
            return Ok(sale);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _saleRepository.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}/isSold")]
        public async Task<IActionResult> Put(int id)
        {
            var result = await _saleRepository.isSold(id);
            return Ok(result);
        }
    
    }
}

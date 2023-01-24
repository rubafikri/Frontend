using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        private readonly IMapper _Mapper;

        public AddressController(IAddressRepository addressRepository , IMapper mapper)
        {
            _addressRepository = addressRepository;
            _Mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressDto createAddressDto)
        {
            var newAddress = createAddressDto.Adapt<Address>();
             await _addressRepository.Create(newAddress);
            return Ok(newAddress);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateAddressDto updateAddressDto)
        {
            var newAddress = updateAddressDto.Adapt<Address>();
            return Ok(await _addressRepository.Update(newAddress));

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var address = await _addressRepository.GetAll();
            return Ok(address);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _addressRepository.Delete(id);
            return Ok(result);
        }

    }
}

using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/contantUs")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContantUsRepository _contantUsRepository;
        public ContactUsController(IContantUsRepository contantUsRepository)
        {
            _contantUsRepository = contantUsRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateContactUsDto createContactUsDto)
        {
            var newContactUs = createContactUsDto.Adapt<ContactUs>();
            var contantUs = await _contantUsRepository.Create(newContactUs);
            return Ok(contantUs);

        }
        [HttpPut]
        public async Task<IActionResult> Update (ContactUs contactUs)
        {
            var contantUs = await _contantUsRepository.Update(contactUs);
            return Ok(contantUs);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contantUs = await _contantUsRepository.GetAll();
            return Ok(contantUs);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _contantUsRepository.Delete(id);
            return Ok(result);
        }

    }
}

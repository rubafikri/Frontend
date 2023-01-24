using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/staticPages")]
    [ApiController]
    public class StaticPageController : ControllerBase
    {
        private readonly IStaticPageRepository _staticPageRepository;
        public StaticPageController(IStaticPageRepository staticPageRepository)
        {
            _staticPageRepository = staticPageRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateStaticPageDto createStaticPageDto)
        {
            var newStaticPage = createStaticPageDto.Adapt<StaticPages>();
            var staticPage = await _staticPageRepository.Create(newStaticPage);
            return Ok(staticPage);

        }
        [HttpPut]
        public async Task<IActionResult> Update(StaticPages staticPages)
        {
            var staticPage = await _staticPageRepository.Update(staticPages);
            return Ok(staticPage);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? PageName)
        {
            var staticPage = await _staticPageRepository.GetAll(PageName);
            return Ok(staticPage);

        }
   

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _staticPageRepository.Delete(id);
            return Ok(result);
        }

    }
}

using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository , IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create([FromForm] CreateAutherDto createAutherDto)
        {
            var newAuther = createAutherDto.Adapt<Authors>();
            var author = await _authorRepository.Create(newAuther);
            return Ok(author);

        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update (UpdateAutherDto updateAutherDto)
        {
            var newAuther = _mapper.Map<Authors>(updateAutherDto);
            var author = await _authorRepository.Update(newAuther);
            return Ok(author);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _authorRepository.GetAll();
            return Ok(author);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
          var result =  await _authorRepository.Delete(id);
            return Ok(result);
        }

    }
}

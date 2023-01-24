using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/bookSuggestions")]
    [ApiController]
    public class BookSuggestionController : ControllerBase
    {
        private readonly IBookSuggestionRepository _bookSuggestionRepository;
        public BookSuggestionController(IBookSuggestionRepository bookSuggestionRepository)
        {
            _bookSuggestionRepository = bookSuggestionRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBookSuggestionDto createBookSuggestionDto)
        {
            var newBookSuggestion = createBookSuggestionDto.Adapt<BookSuggestion>();
            var bookSuggestion = await _bookSuggestionRepository.Create(newBookSuggestion);
            return Ok(bookSuggestion);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateBookSuggestionDto updateBookSuggestionDto)
        {
            var newBookSuggestion = updateBookSuggestionDto.Adapt<BookSuggestion>();
            var bookSuggestion = await _bookSuggestionRepository.Update(newBookSuggestion);
            return Ok(bookSuggestion);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookSuggestion = await _bookSuggestionRepository.GetAll();
            return Ok(bookSuggestion);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var result =  await _bookSuggestionRepository.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}/isRead")]
        public async Task<IActionResult> Put(int id)
        {
            var result = await _bookSuggestionRepository.isRead(id);
            return Ok(result);
        }

    }
}

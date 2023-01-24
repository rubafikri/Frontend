using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Models;
using BookStore.API.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImageUploaderService _uploaderService;

        public BookController(IBookRepository bookRepository, IImageUploaderService uploaderService)
        {
            _bookRepository = bookRepository;
            _uploaderService = uploaderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchKey)
        {
            var books = await _bookRepository.GetAll(searchKey);
            return Ok(books);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _bookRepository.GetById(id);
            return Ok(books);

        }

        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetAllByCategory(int id)
        {
            var books = await _bookRepository.GetAllByCategory(id);
            return Ok(books);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBookDto createBookDto)
        {
            var newBook = createBookDto.Adapt<Books>();
            newBook.Image = await _uploaderService.UploadImageAsync(createBookDto.Image);

            var book = await _bookRepository.Create(newBook);
            return Ok(book);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBookDto updateBookDto)
        {
            var newBook = updateBookDto.Adapt<Books>();
            newBook.Image = await _uploaderService.UploadImageAsync(updateBookDto.Image);
            var updatedbook = await _bookRepository.Update(newBook);
            return Ok(updatedbook);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.Delete(id);
            return Ok(book);
        }

    }
}

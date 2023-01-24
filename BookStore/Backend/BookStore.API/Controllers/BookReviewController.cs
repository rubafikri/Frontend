using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/bookReviews")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewRepository _bookReviewRepository;
        public BookReviewController(IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBookReviewDto createBookReviewDto)
        {
            var newBookReview = createBookReviewDto.Adapt<BookReview>();
            var bookReview = await _bookReviewRepository.Create(newBookReview);
            return Ok(bookReview);

        }


        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetAll(int bookId)
        {
            var bookReview = await _bookReviewRepository.GetBookRating(bookId);
            return Ok(bookReview);

        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookReviewDto updateBookReviewDto)
        {
            var newBookReview = updateBookReviewDto.Adapt<BookReview>();
            var bookReview = await _bookReviewRepository.Update(newBookReview);
            return Ok(bookReview);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookReviewRepository.Delete(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<List<BookReview>> GetAll()
        {
            return await _bookReviewRepository.GetAll();
        }
    }
}

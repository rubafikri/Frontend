using BooksApiExample.Data;
using BooksApiExample.DTOs;
using BooksApiExample.Interfaces;
using BooksApiExample.Models;
using BooksApiExample.Reposeties;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BooksApiExample.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;
        private readonly IStringLocalizer<BookController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly IMapper _mapper;

        public BookController(IBookRepo bookRepo , 
            IStringLocalizer<BookController> stringLocalizer ,
            IStringLocalizer<SharedResources> sharedResources,
            IMapper mapper)
        {
            _bookRepo = bookRepo;
            _stringLocalizer = stringLocalizer;
            _sharedResources = sharedResources;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Books from Database
        /// </summary>
        /// <returns>List of books </returns>
        /// <response code="200">Getting books done</response>
        /// <response code="404">Books Not Found</response>
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
         
             return Ok(await _bookRepo.getAll());
           

    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var title = _stringLocalizer["Title"];
            var sharedTitle = _sharedResources["Title" , "Ruba"];
            var book = await _bookRepo.GetById(id);
            //return book;
            if (book == null)
                return NotFound();
            else
                return Ok(new { book = book , title  = title , sharedTitle = sharedTitle});
        }

        /// <summary>
        /// Adds New Book 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///        "id": 1,
        ///        "Title": "Book 1"
        ///     }
        ///
        /// </remarks>
        /// <param name="book"> Book </param>
        /// <returns></returns>
        /// <response code="200">Successfully Added Book</response>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Post(Book book)
        {
            Book bookAdded = await _bookRepo.Add(book);
            return Ok(bookAdded);
        }
    }

   
}

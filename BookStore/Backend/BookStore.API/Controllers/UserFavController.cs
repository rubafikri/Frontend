using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/userFav")]
    [ApiController]
    public class UserFavController : ControllerBase
    {
        private readonly IUserFav _userFav;

        public UserFavController(IUserFav userFav)
        {
            _userFav = userFav;
        }

        [HttpPost]
        public async Task<IActionResult> Create(createUserFavDto userFav)
        {
            var newUserFav = userFav.Adapt<UserFavorite>();
            await _userFav.Create(newUserFav);
            return Ok(userFav);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userFav.GetAll());
        }
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Delete(int bookId)
        {


            var result = await _userFav.Delete(bookId);
            return Ok(result);
        }

    }
}

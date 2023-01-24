using BookStore.API.Interfaces;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("{appUserId}")]
        public async Task<IActionResult> GetAllByUserId(string appUserId)
        {
            var user = await _userRepo.GetAll(appUserId);
            return Ok(user);

        }
    }
}

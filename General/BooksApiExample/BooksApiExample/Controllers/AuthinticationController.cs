using BooksApiExample.DTOs;
using BooksApiExample.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BooksApiExample.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthinticationController : ControllerBase
    {

        private readonly IJwtTokenGenerator _jwtToken;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthinticationController(IJwtTokenGenerator jwtToken , UserManager<IdentityUser> userManager , IMapper mapper)
        {
            _jwtToken = jwtToken;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            var token = "";
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                token = _jwtToken.Generate(user);
            }
            else
                throw new UnauthorizedAccessException();

            return Ok(new { token = token });
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterRequestDto registerRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(registerRequestDto.Email);
            if(user != null)
            {
                return BadRequest("User Exists");
            }
            var identityUser = _mapper.Map<IdentityUser>(registerRequestDto);

            //IdentityUser identityUser = new IdentityUser {
            //    Email = registerRequestDto.Email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = registerRequestDto.Username

            //};

            var result = await _userManager.CreateAsync(identityUser , registerRequestDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest("There is error");
            }

            var token = _jwtToken.Generate(identityUser);

            return Ok(new RegisterResponseDto { Email = identityUser.Email, token = token, Username = identityUser.UserName });
        }

    }
}

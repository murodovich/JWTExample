using JWTExample.Dtos;
using JWTExample.Entities;
using JWTExample.Hash;
using JWTExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }


        [HttpPost]
        public async ValueTask<IActionResult> Login(UserDto createDto)
        {
            IEnumerable<Users> users = await _userService.GetAllAsync();

            Users? user = users.FirstOrDefault(x => x.UserName == createDto.UserName && x.PasswordHash == Hash512.ComputeHash512(createDto.Password));

            if (user == null)
                return NotFound("Login yo password hato");

            string token = _authService.GenerateToken(createDto);

            return Ok(token);
        }


    }
}

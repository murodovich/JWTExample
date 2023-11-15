using JWTExample.Dtos;
using JWTExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {

            var result = await _userService.GetAllAsync();
            return Ok(result);

        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserDto userDto)
        {
            int result = await _userService.CreateAsync(userDto);
            return Ok(result);
        }
    }
}

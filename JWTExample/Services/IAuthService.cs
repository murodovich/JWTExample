using JWTExample.Dtos;

namespace JWTExample.Services
{
    public interface IAuthService
    {
        public string GenerateToken(UserDto userDto);

    }
}

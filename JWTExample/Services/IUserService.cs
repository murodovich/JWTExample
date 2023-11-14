using JWTExample.Dtos;
using JWTExample.Entities;

namespace JWTExample.Services
{
    public interface IUserService
    {
        public ValueTask<int> CreateAsync(UserDto userdto);
        public ValueTask<IEnumerable<Users>> GetAllAsync();

    }
}

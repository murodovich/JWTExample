using JWTExample.AppDbContext;
using JWTExample.Dtos;
using JWTExample.Entities;
using JWTExample.Hash;
using Microsoft.EntityFrameworkCore;

namespace JWTExample.Services
{
    public class UserService : IUserService
    {
        private AppDBContext _dbContext;

        public UserService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<int> CreateAsync(UserDto userdto)
        {
            Users users = new Users();
            users.UserName = userdto.UserName;
            users.PasswordHash = Hash512.ComputeHash512(userdto.Password);
            await _dbContext.Users.AddAsync(users);
            int result = await _dbContext.SaveChangesAsync();
            return result;           
        }

        public async ValueTask<IEnumerable<Users>> GetAllAsync()
        {
            IEnumerable<Users> users = await _dbContext.Users.ToListAsync();
            return users;
        }
    }
}

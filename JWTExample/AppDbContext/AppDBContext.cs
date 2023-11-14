using JWTExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTExample.AppDbContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {

        }

        public DbSet<Users> Users { get; set; }

    }
}

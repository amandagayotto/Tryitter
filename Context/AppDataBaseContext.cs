using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Context
{
    public class AppDataBaseContext : DbContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options)
        {}

        public DbSet<User>? Users { get; set; }
        public DbSet<Post>? Posts { get; set; }
    }
}
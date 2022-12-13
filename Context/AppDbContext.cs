using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {}
    public AppDbContext() {}
    public DbSet<User>? Users { get; set; }
    public DbSet<TryitterPost>? TryitterPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"
                Server=127.0.0.1;
                Database=tryitter_db;
                User=SA;
                Password=#Trybe2022;
            ");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Context;

public class TryitterContext : DbContext
{
    public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) 
    { }
    public TryitterContext() {}
    public DbSet<User>? Users { get; set; }
    public DbSet<Post>? Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"
                Server=127.0.0.1;
                Database=tryitter_db;
                User=SA;
                Password=trybe22;
            ");
        }
    }
}
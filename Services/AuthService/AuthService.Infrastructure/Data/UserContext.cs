using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public class UserContext : DbContext, IUserContext
{
    public DbSet<Teacher> Teachers { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;

    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    { 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RusParksDb;Username=postgres;Password=1111");
    }
}
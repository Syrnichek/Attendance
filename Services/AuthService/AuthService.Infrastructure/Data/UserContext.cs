using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AttendanceDb;Username=postgres;Password=1111");
    }
}
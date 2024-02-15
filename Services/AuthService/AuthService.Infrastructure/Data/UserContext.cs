using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public class UserContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<User> Users { get; set; } = null!;

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        
    }
}
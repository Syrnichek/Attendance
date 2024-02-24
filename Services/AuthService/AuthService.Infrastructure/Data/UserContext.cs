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
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AuthAttendanceDb;Username=postgres;Password=1111", 
            b => b.MigrationsAssembly("AuthService.API"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User{Id = 1, UserName = "Жмышенко Валерий", Password = "54321", UserRole = UserRole.Teacher},
            new User{Id = 2, UserName = "Зубенко Михаил", Password = "12345", UserRole = UserRole.Student}
        );
    } 
}
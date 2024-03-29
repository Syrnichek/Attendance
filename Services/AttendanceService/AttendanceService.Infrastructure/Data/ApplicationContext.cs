using AttendanceService.Core.Entities;
using AttendanceService.Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace AttendanceService.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Lesson> Lessons { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;
    
    public DbSet<Teacher> Teachers { get; set; } = null!;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AttendanceDb;Username=postgres;Password=1111", 
            b => b.MigrationsAssembly("AttendanceService.API"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new Student{Id = 2, UserName = "Зубенко Михаил", StudentFlagEnum = StudentFlagEnum.Absented, UserRole = UserRoleEnum.Student}
        );
    } 
}
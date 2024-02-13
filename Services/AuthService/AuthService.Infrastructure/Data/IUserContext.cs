using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public interface IUserContext
{
    public DbSet<Teacher> Teachers { get; set; } 

    public DbSet<Student> Students { get; set; } 
}
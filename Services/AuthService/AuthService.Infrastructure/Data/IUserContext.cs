using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Data;

public interface IUserContext
{
    public DbSet<User> Users { get; set; }
}
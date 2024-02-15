using AuthService.Core.Entities;
using AuthService.Core.Repositories;
using AuthService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IUserContext _userContext;
    
    public UserRepository(IUserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<User> GetUser(int id)
    {
        return await _userContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
}
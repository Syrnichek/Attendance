using AuthService.Core.Entities;
using AuthService.Core.Repositories;
using AuthService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;
    
    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await _userContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
}
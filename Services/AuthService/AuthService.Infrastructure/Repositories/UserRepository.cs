using AuthService.Core.Repositories;
using AuthService.Infrastructure.Data;

namespace AuthService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IUserContext _userContext;
    
    public UserRepository(IUserContext userContext)
    {
        _userContext = userContext;
    }
}
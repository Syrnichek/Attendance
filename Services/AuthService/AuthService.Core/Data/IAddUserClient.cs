using AuthService.Core.Entities;
using AuthService.Core.Responses;

namespace AuthService.Core.Data;

public interface IRegisterUserClient
{
    public Task<User> RegisterUserAsync(RegisterUserResponse user);
}
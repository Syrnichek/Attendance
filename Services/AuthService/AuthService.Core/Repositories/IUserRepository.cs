using AuthService.Core.Entities;

namespace AuthService.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserAsync(string userName, string password);

    public Task RegisterUserAsync(User user);
}
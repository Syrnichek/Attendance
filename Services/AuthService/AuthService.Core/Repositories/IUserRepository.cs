using AuthService.Core.Entities;

namespace AuthService.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserAsync(string userName, string password);

    public Task RegisterUserAsync(string userName, string password, UserRole userRole);
}
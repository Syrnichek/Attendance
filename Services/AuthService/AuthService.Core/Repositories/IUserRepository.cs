using AuthService.Core.Entities;

namespace AuthService.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetUser(int id);
}
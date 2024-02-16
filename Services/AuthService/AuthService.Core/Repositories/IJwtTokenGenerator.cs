using AuthService.Core.Entities;

namespace AuthService.Core.Repositories;

public interface IJwtTokenGenerator
{
    public string GenerateJwtToken(int id, string userName, UserRole userRole);
}
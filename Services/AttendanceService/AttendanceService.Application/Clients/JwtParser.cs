using System.IdentityModel.Tokens.Jwt;
using AttendanceService.Core.Responses;
using JwtParserService.Core.Entities;

namespace AttendanceService.Application.Clients;

public class JwtParser
{
    public Task<UserResponse> ParseJwt(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jsonToken = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

        if (jsonToken != null)
        {
            string? id = jsonToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;  // NameIdentifier
            string? userName = jsonToken.Claims.FirstOrDefault(c => c.Type == "userName")?.Value;  // Name
            string? role = jsonToken.Claims.FirstOrDefault(c => c.Type == "userRole")?.Value;  // Role

            Enum.TryParse(role, out UserRole userRole);
            var userId = int.Parse(id); 
            
            return Task.FromResult(new UserResponse
            {
                Id = userId, 
                UserName = userName,
                UserRole = userRole
            });
        }

        return Task.FromResult<UserResponse>(null);
    }
}
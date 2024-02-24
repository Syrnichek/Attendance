using System.IdentityModel.Tokens.Jwt;
using AuthService.Application.Commands;
using AuthService.Application.Responses;
using AuthService.Core.Entities;
using MediatR;

namespace AuthService.Application.Handlers;

public class ParseJwtCommandHandler : IRequestHandler<ParseJwtCommand, UserResponse>
{
    public Task<UserResponse> Handle(ParseJwtCommand request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jsonToken = tokenHandler.ReadToken(request.Token) as JwtSecurityToken;

        if (jsonToken != null)
        {
            string id = jsonToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;  // NameIdentifier
            string userName = jsonToken.Claims.FirstOrDefault(c => c.Type == "userName")?.Value;  // Name
            string role = jsonToken.Claims.FirstOrDefault(c => c.Type == "userRole")?.Value;  // Role

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
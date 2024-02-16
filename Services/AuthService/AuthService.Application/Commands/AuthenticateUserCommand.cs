using MediatR;

namespace AuthService.Application.Commands;

public class AuthenticateUserCommand : IRequest<string>
{
    public string Username { get; set; }
    
    public string Password { get; set; }
}
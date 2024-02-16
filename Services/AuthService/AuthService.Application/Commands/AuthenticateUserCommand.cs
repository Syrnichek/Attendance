using MediatR;

namespace AuthService.Application.Commands;

public class AuthenticateUserCommand : IRequest<string>
{
    public AuthenticateUserCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; set; }
    
    public string Password { get; set; }
}
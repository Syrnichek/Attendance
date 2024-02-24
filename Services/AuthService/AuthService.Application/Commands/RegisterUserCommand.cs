using AuthService.Core.Entities;
using MediatR;

namespace AuthService.Application.Commands;

public class RegisterUserCommand : IRequest
{
    public RegisterUserCommand(string username, string password)
    {
        UserName = username;
        Password = password;
    }

    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public UserRole UserRole { get; set; }
    
    public string? UserNote { get; set; }
}
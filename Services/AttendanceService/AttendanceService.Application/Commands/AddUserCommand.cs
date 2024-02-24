using JwtParserService.Core.Entities;
using MediatR;

namespace AttendanceService.Application.Commands;

public class AddUserCommand : IRequest
{
    public AddUserCommand(string username, string password)
    {
        UserName = username;
        Password = password;
    }

    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public UserRole UserRole { get; set; }
    
    public string? UserNote { get; set; }
}
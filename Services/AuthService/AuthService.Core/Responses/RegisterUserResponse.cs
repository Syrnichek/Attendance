using AuthService.Core.Entities;

namespace AuthService.Core.Responses;

public class RegisterUserResponse
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public UserRole UserRole { get; set; }
    
    public string? UserNote { get; set; }
}
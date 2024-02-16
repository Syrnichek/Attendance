using System.ComponentModel.DataAnnotations;
using AuthService.Core.Entities;

namespace AuthService.Application.Responses;

public class UserResponse
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public UserRole UserRole { get; set; }
}
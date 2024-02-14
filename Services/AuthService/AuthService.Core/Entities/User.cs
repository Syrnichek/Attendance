using System.ComponentModel.DataAnnotations;

namespace AuthService.Core.Entities;

public class User
{
    public User(string userName, string password, Enum userRole)
    {
        UserName = userName;
        Password = password;
        UserRole = userRole;
    }

    [Key]
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public Enum UserRole { get; set; }
}
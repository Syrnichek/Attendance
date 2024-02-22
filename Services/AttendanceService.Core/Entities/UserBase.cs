using System.ComponentModel.DataAnnotations;

namespace AttendanceService.Core.Entities;

public class UserBase
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; }

    public UserRoleEnum UserRole { get; set; }
}
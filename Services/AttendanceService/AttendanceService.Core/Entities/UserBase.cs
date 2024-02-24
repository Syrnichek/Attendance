using System.ComponentModel.DataAnnotations;
using AttendanceService.Core.Entities.Enums;

namespace AttendanceService.Core.Entities;

public class UserBase
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; }

    public UserRoleEnum UserRole { get; set; }
}
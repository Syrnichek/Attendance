using System.ComponentModel.DataAnnotations;
using AttendanceService.Core.Entities.Enums;

namespace AttendanceService.Core.Entities;

public class UserBase
{
    public string UserName { get; set; }

    public UserRoleEnum UserRole { get; set; }
}
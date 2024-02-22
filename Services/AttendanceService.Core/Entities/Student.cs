using AttendanceService.Core.Entities.Enums;

namespace AttendanceService.Core.Entities;

public class Student : UserBase
{
    public StudentFlagEnum StudentFlagEnum { get; set; }
}
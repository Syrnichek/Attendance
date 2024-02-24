using System.ComponentModel.DataAnnotations;
using AttendanceService.Core.Entities.Enums;

namespace AttendanceService.Core.Entities;

public class Teacher : UserBase
{
    [Key]
    public int Id { get; set; }
    
    public TeacherGradeEnum TeacherGradeEnum { get; set; }
}
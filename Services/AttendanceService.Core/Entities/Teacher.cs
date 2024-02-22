namespace AttendanceService.Core.Entities;

public class Teacher : UserBase
{
    public TeacherGradeEnum TeacherGradeEnum { get; set; }
    
    public string? Note { get; set; }
}
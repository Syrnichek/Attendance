namespace AttendanceService.Core.Entities;

public class AddLessonResponse
{
    public int TeacherId { get; set; }
    
    public List<int> StudentIds { get; set; }
}
namespace AttendanceService.Application.Responses;

public class AddLessonResponse
{
    public int TeacherId { get; set; }
    
    public List<int> StudentIds { get; set; }
}
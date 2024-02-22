namespace AttendanceService.Application.Responses;

public class AddLessonResponse
{
    public string TeacherId { get; set; }
    
    public List<string> StudentIds { get; set; }
}
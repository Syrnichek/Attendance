namespace LessonsManagmentService.Application.Responses;

public class LessonResponse
{
    public Guid LessonId { get; set; }

    public string TeacherId { get; set; }
    
    public List<string> StudentIds { get; set; }
    
    public byte[] QrCode { get; set; }
}
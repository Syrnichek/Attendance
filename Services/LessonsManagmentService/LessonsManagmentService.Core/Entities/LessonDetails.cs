namespace LessonsManagmentService.Core.Entities;

public class LessonDetails
{
    public Guid LessonId { get; set; }

    public string TeacherId { get; set; }
    
    public List<string> StudentIds { get; set; }
    
    public byte[] QrCode { get; set; }
}
namespace AttendanceService.Core.Entities;

public class Lesson
{
    public Guid LessonId { get; set; }

    public int TeacherId { get; set; }
    
    public List<int> StudentIds { get; set; }
    
    public byte[] QrCode { get; set; }
}
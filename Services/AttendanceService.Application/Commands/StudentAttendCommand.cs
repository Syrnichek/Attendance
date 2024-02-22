using MediatR;

namespace AttendanceService.Application.Commands;

public class StudentAttendCommand : IRequest
{
    public Guid LessonId { get; set; }
    
    public string StudentJwt { get; set; }
}
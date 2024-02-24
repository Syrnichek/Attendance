using MediatR;

namespace AttendanceService.Application.Commands;

public class StudentAttendCommand : IRequest
{
    public StudentAttendCommand(string studentJwt)
    {
        StudentJwt = studentJwt;
    }

    public Guid LessonId { get; set; }
    
    public string StudentJwt { get; set; }
}
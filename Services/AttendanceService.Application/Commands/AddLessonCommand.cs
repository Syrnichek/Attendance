using MediatR;

namespace AttendanceService.Application.Commands;

public class AddLessonCommand : IRequest
{
    public string TeacherJwt { get; set; }
}
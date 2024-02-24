using MediatR;

namespace AttendanceService.Application.Commands;

public class AddLessonCommand : IRequest<string>
{
    public AddLessonCommand(string teacherJwt)
    {
        TeacherJwt = teacherJwt;
    }

    public string TeacherJwt { get; set; }
}
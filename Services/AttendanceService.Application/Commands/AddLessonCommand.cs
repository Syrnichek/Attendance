using MediatR;

namespace AttendanceService.Application.Commands;

public class AddLessonCommand : IRequest
{
    public string TeacherId { get; set; }
    
    public List<string> StudentIds { get; set; }
}
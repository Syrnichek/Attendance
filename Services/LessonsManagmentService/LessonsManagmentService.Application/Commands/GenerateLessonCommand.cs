using LessonsManagmentService.Application.Responses;
using MediatR;

namespace LessonsManagmentService.Application.Commands;

public class GenerateLessonCommand : IRequest<LessonResponse>
{
    public GenerateLessonCommand(string teacherId, List<string> studentIds)
    {
        TeacherId = teacherId;
        StudentIds = studentIds;
    }

    public string TeacherId { get; set; }
    
    public List<string> StudentIds { get; set; }
}
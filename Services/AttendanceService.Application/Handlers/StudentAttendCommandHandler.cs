using AttendanceService.Application.Commands;
using AttendanceService.Core.Data;
using AttendanceService.Core.Entities.Enums;
using AttendanceService.Core.Repositories;
using MediatR;

namespace AttendanceService.Application.Handlers;

public class StudentAttendCommandHandler : IRequestHandler<StudentAttendCommand>
{
    private readonly ILessonRepository _lessonRepository;

    private readonly IJwtParserClient _jwtParserClient;

    public StudentAttendCommandHandler(ILessonRepository lessonRepository, IJwtParserClient jwtParserClient)
    {
        _lessonRepository = lessonRepository;
        _jwtParserClient = jwtParserClient;
    }

    public async Task Handle(StudentAttendCommand request, CancellationToken cancellationToken)
    {
        var studentInfo = await _jwtParserClient.ParseJwtAsync(request.StudentJwt);

        var lessonInfo = await _lessonRepository.GetLessonByGuid(request.LessonId);

        var student = lessonInfo.StudentIds.Find(s => s.Id == studentInfo.Id);
        
        if (student != null)
        {
            student.StudentFlagEnum = StudentFlagEnum.Attended;
        }
    }
}
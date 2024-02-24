using AttendanceService.Application.Clients;
using AttendanceService.Application.Commands;
using AttendanceService.Core.Entities.Enums;
using AttendanceService.Core.Repositories;
using MediatR;

namespace AttendanceService.Application.Handlers;

public class StudentAttendCommandHandler : IRequestHandler<StudentAttendCommand>
{
    private readonly ILessonRepository _lessonRepository;

    private readonly IStudentRepository _studentRepository;

    public StudentAttendCommandHandler(ILessonRepository lessonRepository, IStudentRepository studentRepository)
    {
        _lessonRepository = lessonRepository;
        _studentRepository = studentRepository;
    }

    public async Task Handle(StudentAttendCommand request, CancellationToken cancellationToken)
    {
        var jwtParser = new JwtParser();
        var studentInfo = await jwtParser.ParseJwt(request.StudentJwt);

        var lessonInfo = await _lessonRepository.GetLessonByGuid(request.LessonId);
        
        var studentId = lessonInfo.StudentIds.Find(s => s == studentInfo.Id);

        var student = await _studentRepository.GetStudentById(studentId);
        
        if (student != null)
        {
            student.StudentFlagEnum = StudentFlagEnum.Attended;
            await _studentRepository.SaveStudent();
        }
    }
}
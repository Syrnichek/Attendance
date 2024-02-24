using AttendanceService.Application.Commands;
using AttendanceService.Core.Data;
using AttendanceService.Core.Entities;
using AttendanceService.Core.Repositories;
using MediatR;

namespace AttendanceService.Application.Handlers;

public class AddLessonComandHandler : IRequestHandler<AddLessonCommand>
{
    private readonly ILessonGeneratorClient _lessonGeneratorClient;

    private readonly IJwtParserClient _jwtParserClient;

    private readonly ILessonRepository _lessonRepository;

    private readonly IStudentRepository _studentRepository;

    public AddLessonComandHandler(ILessonGeneratorClient lessonGeneratorClient, ILessonRepository lessonRepository, IJwtParserClient jwtParserClient, IStudentRepository studentRepository)
    {
        _lessonGeneratorClient = lessonGeneratorClient;
        _lessonRepository = lessonRepository;
        _jwtParserClient = jwtParserClient;
        _studentRepository = studentRepository;
    }

    public async Task Handle(AddLessonCommand request, CancellationToken cancellationToken)
    {
        var teacherJwt = await _jwtParserClient.ParseJwtAsync(request.TeacherJwt);

        var students = await _studentRepository.GetAllStudents();
        var studentsIds = new List<int>();
        
        foreach (var s in students)
        {
            studentsIds.Add(s.Id);
        }
        
        var lessonsModel = new AddLessonResponse
        {
            TeacherId = teacherJwt.Id,
            StudentIds = studentsIds
        };
        
        var lesson = await _lessonGeneratorClient.GenerateLessonAsync(lessonsModel);

        await _lessonRepository.AddLesson(lesson);
    }
}
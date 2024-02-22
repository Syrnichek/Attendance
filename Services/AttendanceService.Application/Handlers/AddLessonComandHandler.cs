using AttendanceService.Application.Clients;
using AttendanceService.Application.Commands;
using AttendanceService.Application.Responses;
using AttendanceService.Core.Repositories;
using MediatR;

namespace AttendanceService.Application.Handlers;

public class AddLessonComandHandler : IRequestHandler<AddLessonCommand>
{
    private readonly LessonGeneratorClient _lessonGeneratorClient;

    private readonly JwtParserClient _jwtParserClient;

    private readonly ILessonRepository _lessonRepository;

    private readonly IStudentRepository _studentRepository;

    public AddLessonComandHandler(LessonGeneratorClient lessonGeneratorClient, ILessonRepository lessonRepository, JwtParserClient jwtParserClient, IStudentRepository studentRepository)
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
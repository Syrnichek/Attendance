using AttendanceService.Application.Clients;
using AttendanceService.Application.Commands;
using AttendanceService.Core.Repositories;
using MediatR;

namespace AttendanceService.Application.Handlers;

public class AddLessonComandHandler : IRequestHandler<AddLessonCommand>
{
    private readonly LessonGeneratorClient _lessonGeneratorClient;

    private readonly ILessonRepository _lessonRepository;

    public AddLessonComandHandler(LessonGeneratorClient lessonGeneratorClient, ILessonRepository lessonRepository)
    {
        _lessonGeneratorClient = lessonGeneratorClient;
        _lessonRepository = lessonRepository;
    }

    public async Task Handle(AddLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonGeneratorClient.GenerateLessonAsync(request);

        await _lessonRepository.AddLesson(lesson);
    }
}
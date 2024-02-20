using LessonsManagmentService.Application.Commands;
using LessonsManagmentService.Application.Responses;
using LessonsManagmentService.Core.Data;
using MediatR;

namespace LessonsManagmentService.Application.Handlers;

public class GenerateLessonCommandHandler : IRequestHandler<GenerateLessonCommand, LessonResponse>
{
    private readonly IQrCodeGeneratorClient _qrCodeGeneratorClient;

    public GenerateLessonCommandHandler(IQrCodeGeneratorClient qrCodeGeneratorClient)
    {
        _qrCodeGeneratorClient = qrCodeGeneratorClient;
    }

    public async Task<LessonResponse> Handle(GenerateLessonCommand request, CancellationToken cancellationToken)
    {
        var lessonIdGuid = Guid.NewGuid();
        var qrCode = await _qrCodeGeneratorClient.GenerateQrCodeAsync(lessonIdGuid.ToString());

        LessonResponse lesson = new LessonResponse
        {
            LessonId = lessonIdGuid,
            TeacherId = request.TeacherId,
            StudentIds = request.StudentIds,
            QrCode = qrCode
        };

        return lesson;
    }
}
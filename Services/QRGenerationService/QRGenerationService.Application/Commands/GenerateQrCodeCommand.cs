using MediatR;

namespace QRGenerationService.Application.Commands;

public class GenerateQrCodeCommand : IRequest<byte[]>
{
    public string LessonId { get; set; }
}
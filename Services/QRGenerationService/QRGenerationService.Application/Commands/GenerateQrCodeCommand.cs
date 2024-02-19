using MediatR;

namespace QRGenerationService.Application.Commands;

public class GenerateQrCodeCommand : IRequest<byte[]>
{
    public Guid LessonId { get; set; }
}
using System.Drawing.Imaging;
using MediatR;
using QRCoder;
using QRGenerationService.Application.Commands;

namespace QRGenerationService.Application.Handlers;

public class GenerateQrCodeCommandHandler : IRequestHandler<GenerateQrCodeCommand, byte[]>
{
    public Task<byte[]> Handle(GenerateQrCodeCommand request, CancellationToken cancellationToken)
    {
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(request.LessonId.ToString( ), QRCodeGenerator.ECCLevel.Q);
        var qrCode = new QRCode(qrCodeData);
        
        using (var stream = new MemoryStream())
        {
            var qrCodeBitmap = qrCode.GetGraphic(20); // 20 - размер пикселя
            qrCodeBitmap.Save(stream, ImageFormat.Png);
            return Task.FromResult(stream.ToArray());
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QRGenerationService.Application.Commands;

namespace QRGenerationService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QrCodeController : ControllerBase
{
    private readonly IMediator _mediator;

    public QrCodeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<byte[]>> GenerateQrCode([FromBody] GenerateQrCodeCommand generateQrCodeCommand)
    {
        var qrCodeBytes  = await _mediator.Send(generateQrCodeCommand);
        return qrCodeBytes;
    }
}
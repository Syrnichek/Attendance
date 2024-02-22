using AttendanceService.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceServiceController : ControllerBase
{
    private readonly IMediator _mediator;
    
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult> AddLesson([FromBody] AddLessonCommand addLessonCommand)
    {
        await _mediator.Send(addLessonCommand);
        return NoContent();
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult> AttendStudent([FromBody] StudentAttendCommand studentAttendCommand)
    {
        await _mediator.Send(studentAttendCommand);
        return NoContent();
    }
}
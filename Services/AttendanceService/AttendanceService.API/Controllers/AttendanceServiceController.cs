using AttendanceService.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttendanceServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<string>> AddLesson([FromBody] AddLessonCommand addLessonCommand)
    {
        return await _mediator.Send(addLessonCommand);
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult> AttendStudent([FromBody] StudentAttendCommand studentAttendCommand)
    {
        try
        {
            await _mediator.Send(studentAttendCommand);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(425, "Пользователь отсутствует в базе");
        }
    }
}
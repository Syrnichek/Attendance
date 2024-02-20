using LessonsManagmentService.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LessonsManagmentService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsManagmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public LessonsManagmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult> GenerateLesson([FromBody] GenerateLessonCommand generateLessonCommand)
    {
        var result = await _mediator.Send(generateLessonCommand);
        return Ok(result);
    }
}
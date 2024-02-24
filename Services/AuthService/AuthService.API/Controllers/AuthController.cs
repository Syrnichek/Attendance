using AuthService.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<string>> AuthUser([FromBody] AuthenticateUserCommand authenticateUserCommand)
    {
        try
        {
            var result = await _mediator.Send(authenticateUserCommand);
            return Ok(result);
        }
        catch (InvalidOperationException) //Поменять экспешн на кастомный, а то не круто
        {
            return Unauthorized();
        }
    }
}
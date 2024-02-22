using AuthService.Application.Responses;
using MediatR;

namespace AuthService.Application.Commands;

public class ParseJwtCommand : IRequest<UserResponse>
{
    public string Token { get; set; }
}
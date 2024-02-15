using AuthService.Application.Responses;
using MediatR;

namespace AuthService.Application.Queries;

public class GetUserByIdQuery : IRequest<UserResponse>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}
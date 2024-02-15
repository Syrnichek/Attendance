using AuthService.Application.Mappers;
using AuthService.Application.Queries;
using AuthService.Application.Responses;
using AuthService.Core.Repositories;
using MediatR;

namespace AuthService.Application.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository; 
    
    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Id);
        
        if (user == null)
            return null;

        var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
        
        return userResponse;
    }
}
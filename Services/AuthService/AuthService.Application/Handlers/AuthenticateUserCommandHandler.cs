using AuthService.Application.Commands;
using AuthService.Core.Repositories;
using MediatR;

namespace AuthService.Application.Handlers;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
{
    public readonly IUserRepository _userRepository;

    public readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticateUserCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(request.Username, request.Password);

        return _jwtTokenGenerator.GenerateJwtToken(user.Id, user.UserName, user.UserRole);
    }
}
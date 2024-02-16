using AuthService.Application.Commands;
using AuthService.Core.Repositories;
using MediatR;

namespace AuthService.Application.Handlers;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
{
    public readonly IUserRepository _UserRepository;

    public readonly IJwtTokenGenerator _JwtTokenGenerator;

    public AuthenticateUserCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _UserRepository = userRepository;
        _JwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        
    }
}
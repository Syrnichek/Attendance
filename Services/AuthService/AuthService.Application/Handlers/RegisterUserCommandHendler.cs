using AuthService.Application.Commands;
using AuthService.Core.Data;
using AuthService.Core.Entities;
using AuthService.Core.Repositories;
using AuthService.Core.Responses;
using MediatR;

namespace AuthService.Application.Handlers;

public class RegisterUserCommandHendler : IRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;

    private readonly IRegisterUserClient _registerUserClient;

    public RegisterUserCommandHendler(IUserRepository userRepository, IRegisterUserClient registerUserClient)
    {
        _userRepository = userRepository;
        _registerUserClient = registerUserClient;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.RegisterUserAsync(new User
        {
            UserName = request.UserName,
            Password = request.Password,
            UserRole = request.UserRole
        });
        await _registerUserClient.RegisterUserAsync(new RegisterUserResponse
        {
            UserName = request.UserName,
            Password = request.Password,
            UserRole = request.UserRole,
            UserNote = request.UserNote
        });
    }
}
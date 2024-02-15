using AuthService.Application.Responses;
using AuthService.Core.Entities;
using AutoMapper;

namespace AuthService.Application.Mappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, UserResponse>();
    }
}
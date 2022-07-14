using AutoMapper;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;

namespace EasyChoresApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegisterDto, User>();
        CreateMap<User, UserDto>();
    }
    
}
using AutoMapper;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;

namespace EasyChoresApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
       
        CreateMap<RegisterDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<User, MemberDto>();
        CreateMap<EventDto, Event>();
        CreateMap<Event, EventDto>();

    }
    
}
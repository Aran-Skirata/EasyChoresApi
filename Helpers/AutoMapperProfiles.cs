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

        CreateMap<EventDto, Event>()
            .ForMember(des => des.UserEvents,
                src => src.MapFrom(
                    src => src.Users.ToList()));
        CreateMap<Event, EventDto>()
            .ForMember(des => des.Users,
                src => src.MapFrom(des => des.UserEvents.ToList()));

    }
    
}
using AutoMapper;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Extensions;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Controllers;

[Authorize]
public class CalendarEventController : BaseApiController
{
    private readonly ICalendarEventRepository _calendarEventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CalendarEventController(ICalendarEventRepository calendarEventRepository, IUserRepository userRepository, IMapper mapper)
    {
        _calendarEventRepository = calendarEventRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CalendarEventDto>> GetCalendarEvents()
    {
        return await _calendarEventRepository.GetEventsAsync();
    }

    [HttpPost]
    public async Task<ActionResult> PostCalendarEvent(CalendarEventDto eventDto)
    {
        var currentUser = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

        var eventEntity = new CalendarEvent()
        {
            Title = eventDto.Title,
            Body = eventDto.Body,
            Category = eventDto.Category,
            StartDate = DateTime.SpecifyKind(eventDto.StartDate.Value,DateTimeKind.Utc),
            EndDate = DateTime.SpecifyKind(eventDto.EndDate.Value, DateTimeKind.Utc),
            FontColor = eventDto.FontColor,
            ThemeColor = eventDto.ThemeColor,
            Location = eventDto.Location,
            Status = eventDto.Status,
            Owner = currentUser
        };
        _calendarEventRepository.AddEvent(eventEntity);
        
        return await _calendarEventRepository.SaveAllAsync() ? Ok() : BadRequest();
    }
    
    [HttpGet("{id}")]
    public async Task<CalendarEventDto> GetCalendarEvent(int id)
    {
        return await _calendarEventRepository.GetEventAsync(id);
    }

    [HttpPatch]
    public async Task<ActionResult<CalendarEventDto>> PutCalendarEvent(CalendarEventDto eventDto)
    {
       var currentUser = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
       if (currentUser.Id != eventDto.OwnerId)
           return Unauthorized();
       _calendarEventRepository.UpdateEvent(_mapper.Map<CalendarEvent>(eventDto));
       
       if (!await _calendarEventRepository.SaveAllAsync())
           return BadRequest("Could not update event");
       return Ok(await _calendarEventRepository.GetEventAsync(eventDto.Id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCalendarEvent(int id)
    {
        var currentUser = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
        var entityToDelete = await _calendarEventRepository.GetEventEntityAsync(id);

        if (currentUser.Id != entityToDelete.OwnerId)
            return Unauthorized();
        _calendarEventRepository.DeleteEvent(entityToDelete);
        
        if (!await _calendarEventRepository.SaveAllAsync())
            return BadRequest("Could not delete event");
        return NoContent();
    }
}
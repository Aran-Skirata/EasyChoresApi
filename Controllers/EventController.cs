using AutoMapper;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Extensions;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Controllers;

[Authorize]
public class EventController : BaseApiController
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public EventController(IEventRepository eventRepository, IUserRepository userRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<EventDto>> GetEvents()
    {
        return await _eventRepository.GetEventsAsync();
    }

    [HttpPost]
    public async Task<ActionResult> PostEvent(EventDto eventDto)
    {
        var currentUser = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

        var eventEntity = new Event()
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
        _eventRepository.AddEvent(eventEntity);
        
        return await _eventRepository.SaveAllAsync() ? Ok() : BadRequest();
    }
    
    [HttpGet("{id}")]
    public async Task<EventDto> GetEvent(int id)
    {
        return await _eventRepository.GetEventAsync(id);
    }

    [HttpPatch]
    public async Task<ActionResult<EventDto>> PutEvent(EventDto eventDto)
    {
       var currentUser = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
       if (currentUser.Id != eventDto.OwnerId)
           return Unauthorized();
       _eventRepository.UpdateEvent(_mapper.Map<Event>(eventDto));
       
       if (!await _eventRepository.SaveAllAsync())
           return BadRequest("Could not update event");
       return Ok(await _eventRepository.GetEventAsync(eventDto.Id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        var currentUser = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
        var entityToDelete = await _eventRepository.GetEventEntityAsync(id);

        if (currentUser.Id != entityToDelete.OwnerId)
            return Unauthorized();
        _eventRepository.DeleteEvent(entityToDelete);
        
        if (!await _eventRepository.SaveAllAsync())
            return BadRequest("Could not delete event");
        return NoContent();
    }
}
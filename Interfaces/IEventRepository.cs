using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Interfaces;

public interface IEventRepository
{
    public void CreateEvent(Event eventEntity);
    public Task<ActionResult<IEnumerable<Event>>> GetEvents();
    public Task<ActionResult<Event>> GetEvent(int eventId);
    public  Task<ActionResult<IEnumerable<EventDto>>> GetEventDtos();
    public Task<ActionResult<EventDto>> GetEventDto(int eventId);
    public void UpdateEvent(Event eventEntity);
    public void DeleteEvent(int eventId);

    public Task<bool> SaveAllAsync();

}
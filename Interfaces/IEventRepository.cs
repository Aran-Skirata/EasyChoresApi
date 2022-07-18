using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Interfaces;

public interface IEventRepository
{
    public Task<EventDto> GetEventAsync(int id);
    public Task<IEnumerable<EventDto>> GetEventsAsync();
    public Task<Event> GetEventEntityAsync(int id);
    public void AddEvent(Event eventEntity);
    public void DeleteEvent(Event eventEntity);
    public void UpdateEvent(Event eventEntity);
    public Task<bool> SaveAllAsync();


}
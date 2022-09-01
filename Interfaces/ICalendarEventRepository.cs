using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Interfaces;

public interface ICalendarEventRepository
{
    public Task<CalendarEventDto> GetEventAsync(int id);
    public Task<IEnumerable<CalendarEventDto>> GetEventsAsync();
    public Task<CalendarEvent> GetEventEntityAsync(int id);
    public void AddEvent(CalendarEvent eventEntity);
    public void DeleteEvent(CalendarEvent eventEntity);
    public void UpdateEvent(CalendarEvent eventEntity);
    public Task<bool> SaveAllAsync();


}
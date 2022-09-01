using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyChoresApi.Data;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyChoresApi.Repositories;

public class CalendarEventRepository : ICalendarEventRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public CalendarEventRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<CalendarEventDto> GetEventAsync(int id)
    {
        return await _dataContext.CalendarEvents.ProjectTo<CalendarEventDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<CalendarEventDto>> GetEventsAsync()
    {
        return await _dataContext.CalendarEvents.ProjectTo<CalendarEventDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<CalendarEvent> GetEventEntityAsync(int id)
    {
        return await _dataContext.CalendarEvents.SingleOrDefaultAsync(e => e.Id == id);
    }

    public void AddEvent(CalendarEvent eventEntity)
    {
        _dataContext.CalendarEvents.Add(eventEntity);
    }

    public void DeleteEvent(CalendarEvent eventEntity)
    {
        _dataContext.CalendarEvents.Remove(eventEntity);
    }

    public void UpdateEvent(CalendarEvent eventEntity)
    {
        _dataContext.Entry(eventEntity).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyChoresApi.Data;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyChoresApi.Repositories;

public class EventRepository : IEventRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public EventRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<EventDto> GetEventAsync(int id)
    {
        return await _dataContext.Events.ProjectTo<EventDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<EventDto>> GetEventsAsync()
    {
        return await _dataContext.Events.ProjectTo<EventDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<Event> GetEventEntityAsync(int id)
    {
        return await _dataContext.Events.SingleOrDefaultAsync(e => e.Id == id);
    }

    public void AddEvent(Event eventEntity)
    {
        _dataContext.Events.Add(eventEntity);
    }

    public void DeleteEvent(Event eventEntity)
    {
        _dataContext.Events.Remove(eventEntity);
    }

    public void UpdateEvent(Event eventEntity)
    {
        _dataContext.Entry(eventEntity).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}
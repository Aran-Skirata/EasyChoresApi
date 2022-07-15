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


    public void CreateEvent(Event eventEntity)
    {
        _dataContext.Events.Add(eventEntity);
    }

    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _dataContext.Events.Include(e => e.UserEvents).ToListAsync();
    }

    public async Task<ActionResult<Event>> GetEvent(int eventId)
    {
        return await _dataContext.Events.Include(e => e.UserEvents).SingleOrDefaultAsync(e => e.Id == eventId);
    }

    public async Task<ActionResult<IEnumerable<EventDto>>> GetEventDtos()
    {
        return await _dataContext.Events.Include(e => e.UserEvents)
            .ProjectTo<EventDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<ActionResult<EventDto>> GetEventDto(int eventId)
    {
        return await _dataContext.Events.Where(e=> e.Id == eventId).Include(e => e.UserEvents)
            .ProjectTo<EventDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
    }

    public void UpdateEvent(Event eventEntity)
    {
        _dataContext.Entry(eventEntity).State = EntityState.Modified;
    }
    

    public async void DeleteEvent(int eventId)
    { 
        _dataContext.Events.Remove(await _dataContext.Events.SingleOrDefaultAsync(e => e.Id == eventId));
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}
using AutoMapper;
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
        return _mapper.Map<EventDto>(await _dataContext.Events.SingleOrDefaultAsync(e => e.Id == id));
    }

    public Task<IEnumerable<EventDto>> GetEventsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetEventEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void AddEvent(Event eventEntity)
    {
        throw new NotImplementedException();
    }

    public void UpdateEvent(Event eventEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }
}
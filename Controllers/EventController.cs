using System.Globalization;
using AutoMapper;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Controllers;

[Authorize]
public class EventController : BaseApiController
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventController(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
    {
        return await _eventRepository.GetEventDtos();
    }


    [HttpPost]
    public async Task<ActionResult> CreateNewEvent(EventDto eventDto)
    {
        
    }
using EasyChoresApi.Data;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;

namespace EasyChoresApi.Repositories;

public class CalendarReminderRepository : ICalendarReminderRepository
{
    private readonly DataContext _dataContext;

    public CalendarReminderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public Task<CalendarReminderDto> GetReminderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CalendarReminderDto>> GetRemindersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CalendarReminder> GetReminderEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void AddReminder(CalendarReminder reminder)
    {
        throw new NotImplementedException();
    }

    public void DeleteReminder(CalendarReminder reminder)
    {
        throw new NotImplementedException();
    }

    public void UpdateReminder(CalendarReminder reminder)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }
}
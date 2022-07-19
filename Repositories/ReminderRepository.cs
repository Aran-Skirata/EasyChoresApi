using EasyChoresApi.Data;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;

namespace EasyChoresApi.Repositories;

public class ReminderRepository : IReminderRepository
{
    private readonly DataContext _dataContext;

    public ReminderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public Task<ReminderDto> GetReminderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ReminderDto>> GetRemindersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Reminder> GetReminderEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void AddReminder(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public void DeleteReminder(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public void UpdateReminder(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }
}
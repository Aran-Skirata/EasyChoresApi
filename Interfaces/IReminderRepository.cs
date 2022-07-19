using EasyChoresApi.DTO;
using EasyChoresApi.Entities;

namespace EasyChoresApi.Interfaces;

public interface IReminderRepository
{
    public Task<ReminderDto> GetReminderAsync(int id);
    public Task<IEnumerable<ReminderDto>> GetRemindersAsync();
    public Task<Reminder> GetReminderEntityAsync(int id);
    public void AddReminder(Reminder reminder);
    public void DeleteReminder(Reminder reminder);
    public void UpdateReminder(Reminder reminder);
    public Task<bool> SaveAllAsync();
}
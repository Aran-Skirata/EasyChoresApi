using EasyChoresApi.DTO;
using EasyChoresApi.Entities;

namespace EasyChoresApi.Interfaces;

public interface ICalendarReminderRepository
{
    public Task<CalendarReminderDto> GetReminderAsync(int id);
    public Task<IEnumerable<CalendarReminderDto>> GetRemindersAsync();
    public Task<CalendarReminder> GetReminderEntityAsync(int id);
    public void AddReminder(CalendarReminder reminder);
    public void DeleteReminder(CalendarReminder reminder);
    public void UpdateReminder(CalendarReminder reminder);
    public Task<bool> SaveAllAsync();
}
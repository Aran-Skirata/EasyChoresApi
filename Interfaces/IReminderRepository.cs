using EasyChoresApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Interfaces;

public interface IReminderRepository
{
    public Task<ActionResult<ReminderDto>> CreateReminder(EventDto eventDto);
    public Task<ActionResult<IEnumerable<ReminderDto>>> GetReminders();
    public Task<ActionResult<ReminderDto>> GetReminder(int reminderId);
    public Task<ActionResult<ReminderDto>> UpdateReminder(int reminderId);
    public Task<ActionResult> DeleteReminder(int reminderId);
}
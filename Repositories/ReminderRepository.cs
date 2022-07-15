using EasyChoresApi.DTO;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Repositories;

public class ReminderRepository : IReminderRepository
{
    public Task<ActionResult<ReminderDto>> CreateReminder(EventDto eventDto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<IEnumerable<ReminderDto>>> GetReminders()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<ReminderDto>> GetReminder(int reminderId)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<ReminderDto>> UpdateReminder(int reminderId)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> DeleteReminder(int reminderId)
    {
        throw new NotImplementedException();
    }
}
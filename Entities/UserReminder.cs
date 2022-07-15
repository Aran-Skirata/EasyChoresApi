using Microsoft.AspNetCore.Identity;

namespace EasyChoresApi.Entities;

public class UserReminder
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public Reminder Reminder { get; set; }
    public int ReminderId { get; set; }
}
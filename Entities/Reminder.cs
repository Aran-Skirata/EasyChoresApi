namespace EasyChoresApi.Entities;

public class Reminder
{
    public int Id { get; set; }
    public string? Body { get; set; }
    public DateTime ReminderTime { get; set; }
    public bool? Status { get; set; }
    public User Owner { get; set; }
    public int OwnerId { get; set; }
    public ICollection<UserReminder> UserReminders { get; set; }
}
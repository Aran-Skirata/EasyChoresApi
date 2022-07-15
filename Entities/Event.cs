namespace EasyChoresApi.Entities;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Body { get; set; }
    public string? Category { get; set; }
    public string? Location { get; set; }
    public bool? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ThemeColor { get; set; }
    public string? FontColor { get; set; }
    public User Owner { get; set; }
    public int OwnerId { get; set; }
    public ICollection<UserEvent> UserEvents { get; set; }
}
using Microsoft.AspNetCore.Identity;

namespace EasyChoresApi.Entities;

public class UserEvent 
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
}
using Microsoft.AspNetCore.Identity;

namespace EasyChoresApi.Entities;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set;  }
    public ICollection<Event> OwnedEvents { get; set; }
    public ICollection<Reminder> OwnedReminders { get; set; }
}
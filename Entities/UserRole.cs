using Microsoft.AspNetCore.Identity;

namespace EasyChoresApi.Entities;

public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; }
    public Role Role { get; set; }
}
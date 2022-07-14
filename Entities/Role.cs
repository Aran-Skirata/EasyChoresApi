using Microsoft.AspNetCore.Identity;

namespace EasyChoresApi.Entities;

public class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; }
}
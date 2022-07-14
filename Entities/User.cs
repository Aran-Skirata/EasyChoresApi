using Microsoft.AspNetCore.Identity;

namespace EasyChoresApi.Entities;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set;  } 
}
using System.ComponentModel.DataAnnotations;

namespace EasyChoresApi.DTO;

public class LoginDto
{
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
}
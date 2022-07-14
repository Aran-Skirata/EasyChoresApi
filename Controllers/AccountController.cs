using EasyChoresApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EasyChoresApi.Controllers;

public class AccountController : BaseApiController
{
    [HttpPost("register")]
    public Task<UserDto> RegisterUser(RegisterDto registerDto)
    {
        //ToDo
    }

    [HttpPost("login")]
    public Task<UserDto> RegisterUser(LoginDto loginDto)
    {
        //ToDo
    }
}
using AutoMapper;
using EasyChoresApi.DTO;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyChoresApi.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
        ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto registerDto)
    {
        if (await _userManager.Users.AnyAsync(u => u.UserName == registerDto.UserName.ToLower()))
            return BadRequest("Username already exists");

        var user = _mapper.Map<User>(registerDto);

        user.UserName = registerDto.UserName.ToLower();

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        
        if (!result.Succeeded) return BadRequest("Could not create user");

        // var roleResult = await _userManager.AddToRoleAsync(user, "User");

        // if (!roleResult.Succeeded) return BadRequest("Could not add role to user");

        return new UserDto
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginUser(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName.ToLower());
        if(user == null) return Unauthorized("Invalid username or password");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Invalid username or password");
        
        return new UserDto
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateToken(user),
        };
    }
}
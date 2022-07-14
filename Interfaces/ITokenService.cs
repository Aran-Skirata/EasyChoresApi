using EasyChoresApi.Entities;

namespace EasyChoresApi.Interfaces;

public interface ITokenService
{   
    Task<string> CreateToken(User user);
}
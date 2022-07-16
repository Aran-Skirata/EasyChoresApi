using EasyChoresApi.Entities;

namespace EasyChoresApi.Interfaces;

public interface IUserRepository
{
    public Task<User> GetUserByUsernameAsync(string username);
}
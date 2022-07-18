using EasyChoresApi.Entities;

namespace EasyChoresApi.Interfaces;

public interface IUserRepository
{
    public Task<User> GetUserByUsernameAsync(string username);
    public Task<User> GetUserByIdAsync(int id);
}
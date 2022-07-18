using EasyChoresApi.Data;
using EasyChoresApi.Entities;
using EasyChoresApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyChoresApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _dataContext.Users.SingleOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _dataContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
}
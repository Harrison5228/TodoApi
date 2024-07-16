using TodoApi.Models;

namespace TodoApi.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User> Login(string username, string password);
    
}
using TodoApi.Models;

namespace TodoApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);
    }
}
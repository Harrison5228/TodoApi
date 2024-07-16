using TodoApi.Helpers;
using TodoApi.Services.Interfaces;
using TodoApi.Models;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.Services
{
    public class AuthService(IUserRepository userRepository, ISessionService sessionService)
        : IAuthService
    {
        public async Task<User> Login(string username, string password)
        {
            var encrypted = EncryptHelper.Encrypt(password);
            var result = await userRepository.Login(username, encrypted);
            
            sessionService.SetSessionUser(result.Username);
            return result;
        }


    }
}
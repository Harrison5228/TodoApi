using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class SessionService(IHttpContextAccessor httpContextAccessor): ISessionService
    {
        public string? GetSessionUser()
        {
            return httpContextAccessor.HttpContext?.Session.GetString("User");
        }

        public void SetSessionUser(string username)
        {
            httpContextAccessor.HttpContext?.Session.SetString("User", username);
        }
    }
}
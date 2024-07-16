namespace TodoApi.Services.Interfaces
{
    public interface ISessionService
    {
        string? GetSessionUser();
        
        void SetSessionUser(string username);
    }
}
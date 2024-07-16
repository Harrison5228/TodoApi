namespace TodoApi.Models.Response;

public class LoginResponse
{
    public required string Username { get; set; }

    public bool IsLogin { get; set; } = false;
}
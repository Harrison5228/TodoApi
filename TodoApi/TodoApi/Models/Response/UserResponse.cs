namespace TodoApi.Models.Response;

public class UserResponse
{
    public required Guid Id { get; set; }
    
    public required string Username { get; set; }
    public required string Password { get; set; }
    
    public List<TodoItem>? TodoItem { get; set; }
}
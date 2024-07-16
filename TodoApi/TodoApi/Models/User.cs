namespace TodoApi.Models;

public class User
{
    public required Guid Id { get; set; } = new();
    public required string Username { get; set; }
    public required string Password { get; set; }
    
    public List<TodoItem>? TodoItem { get; set; }
}
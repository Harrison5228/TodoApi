namespace TodoApi.Models.Request;

public class CreateTodoRequest
{
    
    public required string Title { get; set; }
    
    public string? Description { get; set; }
     
    /// Set by Controller
    public required string Username { get; set; }
}
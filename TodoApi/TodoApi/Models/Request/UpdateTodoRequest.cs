namespace TodoApi.Models.Request;

public class UpdateTodoRequest
{
    public Guid Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;
    
}
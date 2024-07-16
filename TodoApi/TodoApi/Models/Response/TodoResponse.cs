namespace TodoApi.Models.Response;

public class TodoResponse
{
    public Guid Id { get; set; }
    
    public required string Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    
    public DateTime? UpdateDateTime { get; set; }
}
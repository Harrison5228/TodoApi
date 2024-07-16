namespace TodoApi.Models;

public class TodoItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required string Title { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreateDateTime { get; set; } = DateTime.Now;
    
    public DateTime? UpdateDateTime { get; set; }
}
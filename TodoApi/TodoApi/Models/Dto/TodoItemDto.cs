namespace TodoApi.Models.Dto;

public class TodoItemDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required string Title { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreateDateTime { get; set; }
    
    public DateTime? UpdateDateTime { get; set; }
    
    public required string Username { get; set; }
}
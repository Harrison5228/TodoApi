namespace TodoApi.Models.ViewModel;

public class TodoViewModel
{
    public Guid Id { get; set; }
    
    public required string Title { get; set; }
    
    public string? Description { get; set; }
    
    //public required string Username { get; set; } // TODO: 搬出去抓session

    public bool IsCompleted { get; set; } = false;
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}
namespace TodoApi.Models.Request;

public class DeleteTodoRequest
{
    public required Guid Id { get; set; }
}
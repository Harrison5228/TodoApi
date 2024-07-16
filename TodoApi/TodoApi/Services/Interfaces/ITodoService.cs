using TodoApi.Models;
namespace TodoApi.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAll(string username);
        
        Task<TodoItem?> Get(Guid id);
        
        Task<Guid> Create(string username, TodoItem todoItem);
        
        Task Update(TodoItem todoItem);
        
        Task Delete(Guid id);
    }
}
using TodoApi.Models;

namespace TodoApi.Repositories.Interfaces;

public interface ITodoRepository
{
    Task<IEnumerable<TodoItem>> GetAll(string username);
    
    Task<TodoItem?> Get(Guid id);
    
    Task<Guid> Create(string username, TodoItem todoItem);
    
    Task<int> Update(TodoItem todoItem);
    
    Task<int> Delete(Guid id);
}
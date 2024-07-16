using AutoMapper;
using TodoApi.Models;
using TodoApi.Models.Dto;
using TodoApi.Models.Request;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class TodoService(ITodoRepository todoRepository) : ITodoService
    {
        public async Task<IEnumerable<TodoItem>> GetAll(string username)
        {
            return await todoRepository.GetAll(username);
        }

        public async Task<TodoItem?> Get(Guid id)
        {
            return await todoRepository.Get(id);
        }

        public async Task<Guid> Create(string username, TodoItem todoItem)
        {
            return await todoRepository.Create(username, todoItem);
        }

        public async Task Update(TodoItem todoItem)
        {
            todoItem.UpdateDateTime = DateTime.Now;
            await todoRepository.Update(todoItem);
            
        }

        public async Task Delete(Guid id)
        {
            await todoRepository.Delete(id);
            //TODO: error handle?
            //ExceptionMiddleware
            //ExceptionActionFilter
            //看攔截什麼樣的Error
        }
    }
}
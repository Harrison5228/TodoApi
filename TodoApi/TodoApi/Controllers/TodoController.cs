using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Models.Request;
using TodoApi.Models.ViewModel;
using TodoApi.Services.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController(ITodoService todoService, IMapper mapper, ISessionService sessionService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TodoViewModel>> GetAll()
        {
            var todoResponses = await todoService.GetAll(sessionService.GetSessionUser()!);
            return mapper.Map<IEnumerable<TodoViewModel>>(todoResponses);

        }

        [HttpGet]
        public async Task<TodoViewModel> Get(Guid id)
        {
            var todoResponse = await todoService.Get(id);
            return mapper.Map<TodoViewModel>(todoResponse);
        }

        [HttpPost]
        public async Task<Guid> Create([FromBody]CreateTodoRequest createTodoRequest)
        {
            var mapResult = mapper.Map<TodoItem>(createTodoRequest);
            var result = await todoService.Create(sessionService.GetSessionUser()!, mapResult);

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]UpdateTodoRequest updateTodoRequest)
        {
            var mapResult = mapper.Map<TodoItem>(updateTodoRequest);
            await todoService.Update(mapResult);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteTodoRequest deleteTodoRequest)
        {
            await todoService.Delete(deleteTodoRequest.Id);
            
            return NoContent();
        }
    }
}
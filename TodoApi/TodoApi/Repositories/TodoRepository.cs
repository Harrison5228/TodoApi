using AutoMapper;
using Dapper;
using TodoApi.Helpers;
using TodoApi.Models;
using TodoApi.Models.Dto;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services.Interfaces;

namespace TodoApi.Repositories;

public class TodoRepository(IConnectionService connectionService, IMapper mapper) : ITodoRepository
{
    public async Task<IEnumerable<TodoItem>> GetAll(string username)
    {
        await using var connection = await connectionService.GetConnection();
        

        var sql = """
                  SELECT id, title, description, iscompleted, username, createDateTime, updatedateTime
                                      FROM [dbo].[TodoItems] WITH (NOLOCK)
                                      WHERE username = @username
                  """;

        var result = await connection.QueryAsync<TodoItemDto>(sql, new { username });
        return mapper.Map<IEnumerable<TodoItem>>(result);
    }

    public async Task<TodoItem?> Get(Guid id)
    {
        await using var connection = await connectionService.GetConnection();
        
        const string sql = """
                           SELECT Id, Title, Description, IsCompleted, Username, CreateDateTime, UpdateDateTime
                                                       from [dbo].[TodoItems] with (nolock) where id = @id
                           """;

        var result = await connection.QuerySingleAsync<TodoItemDto>(sql, new { id });
        return mapper.Map<TodoItem>(result);
    }

    public async Task<Guid> Create(string username, TodoItem todoItem)
    {
        await using var connection = await connectionService.GetConnection();
        
        const string sql = """
                           INSERT INTO [dbo].[TodoItems] (Id, Title, Description, Username, IsCompleted)
                                                   VALUES (@Id, @Title, @Description, @Username, @IsCompleted)
                           """;
        var mapResult = mapper.Map<TodoItemDto>(todoItem);
        mapResult.Username = username;

        var result = await connection.ExecuteAsync(sql, mapResult);
        
        //TODO: ErrorHandle
        if (result == 0)
            throw new Exception();
        
        return todoItem.Id;
    }

    public async Task<int> Update(TodoItem todoItem)
    {
        await using var connection = await connectionService.GetConnection();
        
        const string sql = """
                           UPDATE [dbo].[TodoItems]
                               SET Title = @Title,
                                   Description = @Description,
                                   IsCompleted = @IsCompleted,
                                   UpdateDateTime = @UpdateDateTime
                               WHERE Id = @Id
                           """;
        var mapResult = mapper.Map<TodoItemDto>(todoItem);

        var count = await connection.ExecuteAsync(sql, mapResult);
        
        if (count == 0)
            throw new Exception();
        
        return count;
    }

    public async Task<int> Delete(Guid id)
    {
        await using var connection = await connectionService.GetConnection();
        
        const string sql = "DELETE FROM [dbo].[TodoItems] WHERE id = @id";

        var count = await connection.ExecuteAsync(sql, new { id });
        
        if (count == 0)
            throw new Exception();
        
        return count;
    }
}
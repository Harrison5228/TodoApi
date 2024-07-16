using AutoMapper;
using Dapper;
using TodoApi.Models;
using TodoApi.Models.Dto;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services.Interfaces;


namespace TodoApi.Repositories;
public class UserRepository(IConnectionService connectionService, IMapper mapper) : IUserRepository
{
    public async Task<User> Login(string username, string password)
    {
        await using var connection = await connectionService.GetConnection();
        
        const string sql = "select Id, Username, Password from [dbo].[User] with (nolock) where username = @username and password = @password";
        var result = await connection.QuerySingleOrDefaultAsync<UserDto>(sql, new { username, password});

        if (string.IsNullOrEmpty(result?.Username))
            throw new Exception();
            
        return mapper.Map<User>(result);
    }
}
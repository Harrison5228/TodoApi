using Microsoft.Data.SqlClient;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services;

public class ConnectionService(IConfiguration configuration): IConnectionService
{
    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    public async Task<SqlConnection> GetConnection()
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}

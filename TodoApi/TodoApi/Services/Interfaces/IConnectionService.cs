using Microsoft.Data.SqlClient;

namespace TodoApi.Services.Interfaces
{
    public interface IConnectionService
    {
        Task<SqlConnection> GetConnection();
    }
}
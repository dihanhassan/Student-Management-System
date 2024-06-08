using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace CRUD.DbConnection
{
    public class DapperDbConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperDbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}

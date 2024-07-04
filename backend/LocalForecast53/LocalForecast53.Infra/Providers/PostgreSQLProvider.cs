using Npgsql;
using System.Data;

namespace LocalForecast53.Infra.Providers
{
    internal class PostgreSQLProvider : IDbProvider
    {
        public IDbConnection GetDbConnection(string connectionString) => 
            new NpgsqlConnection(connectionString);
    }
}

using LocalForecast53.Infra.Providers;
using System.Data;

namespace LocalForecast53.Infra.Contexts
{
    internal class SQLDbContext
    {
        private IDbProvider _dbProvider;
        public SQLDbContext(string providerType) => _dbProvider = providerType switch
        {
            "Npgsql" => _dbProvider = new PostgreSQLProvider(),
            _ => null
        };

        public IDbConnection GetDbContext(string connectionString)
            => _dbProvider.GetDbConnection(connectionString);
    }
}

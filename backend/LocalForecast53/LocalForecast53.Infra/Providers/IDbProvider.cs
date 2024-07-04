using System.Data;

namespace LocalForecast53.Infra.Providers
{
    internal interface IDbProvider
    {
        IDbConnection GetDbConnection(string connectionString);
    }
}

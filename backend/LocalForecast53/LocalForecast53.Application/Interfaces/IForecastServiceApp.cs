using LocalForecast53.Application.Inputs;
using LocalForecast53.Application.Outputs;

namespace LocalForecast53.Application.Interfaces
{
    public interface IForecastServiceApp
    {
        Task<ForecastOutput> GetForecastAsync(ForecastInput forecastInput);
    }
}

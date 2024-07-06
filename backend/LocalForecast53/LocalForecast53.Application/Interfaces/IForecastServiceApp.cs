using LocalForecast53.Application.External;
using LocalForecast53.Application.Inputs;
using LocalForecast53.Application.Output;

namespace LocalForecast53.Application.Interfaces
{
    public interface IForecastServiceApp
    {
        Task<ForecastOutput> GetForecastAsync(ForecastInput forecastInput);
    }
}

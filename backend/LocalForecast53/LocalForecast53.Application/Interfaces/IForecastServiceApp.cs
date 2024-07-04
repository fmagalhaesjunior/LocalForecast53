using LocalForecast53.Application.External;
using LocalForecast53.Application.Inputs;

namespace LocalForecast53.Application.Interfaces
{
    public interface IForecastServiceApp
    {
        Task<OpenWeatherData> GetForecastAsync(ForecastInput forecastInput);
    }
}

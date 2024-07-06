using LocalForecast53.Application.External;

namespace LocalForecast53.Application.Output
{
    public class ForecastOutput
    {
        public CurrentWeather Current { get; set; }
        public OpenWeatherData DataList { get; set; }
    }
}

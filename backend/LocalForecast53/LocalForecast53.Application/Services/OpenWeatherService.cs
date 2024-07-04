using LocalForecast53.Application.External;
using LocalForecast53.Shared.Helpers;

namespace LocalForecast53.Application.Services
{
    public class OpenWeatherService
    {
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5";
        private decimal? _latitude = null;
        private decimal? _longitude = null;
        private string? _unit = null;
        private string apiKey = "bdc71902dd52b3689449314887dd0df6";

        public OpenWeatherService(decimal latitude, decimal longitude, string unit)
        {
            _latitude = latitude;
            _longitude = longitude;
            _unit = unit;
        }

        public async Task<OpenWeatherData> ForecastAsync()
        {
            using (var api = new APIHelper())
            {
                string url = $"{_baseUrl}/forecast?lat={_latitude}&lon={_longitude}&appid={apiKey}&units={_unit}";
                var result = await api.GetAsync<OpenWeatherData>(url);
                return result;
            }
        }
    }
}

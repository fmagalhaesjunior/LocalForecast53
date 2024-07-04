using AutoMapper;
using LocalForecast53.Application.Inputs;
using LocalForecast53.Application.Interfaces;
using LocalForecast53.Application.Outputs;

namespace LocalForecast53.Application.Services
{
    public class ForecastServiceApp : IForecastServiceApp
    {
        private readonly IMapper _mapper;

        public ForecastServiceApp(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<ForecastOutput> GetForecastAsync(ForecastInput forecastInput)
        {
            var openWeatherService = new OpenWeatherService(forecastInput.Latitude, forecastInput.Longitude, GetUnitString(forecastInput.Unit));

            //1. Obter retorno da API externa (OpenWeather)
            var resultApi = openWeatherService.ForecastAsync();

            //2. Mapear retorno com Output
            var output = _mapper.Map<ForecastOutput>(resultApi.Result);

            //3. Persistir os dados no banco

            //4. Retornar Output
            return Task.FromResult(output);
        }

        private string GetUnitString(Units units) => units switch
        {
            Units.Fahrenheit => "imperial",
            Units.Celsius => "metric",
            _ => throw new ArgumentOutOfRangeException(nameof(units), units, null)
        };
    }
}

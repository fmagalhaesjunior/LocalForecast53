using AutoMapper;
using LocalForecast53.Application.External;
using LocalForecast53.Application.Inputs;
using LocalForecast53.Application.Interfaces;
using LocalForecast53.Application.Output;
using LocalForecast53.Core.Entities;
using LocalForecast53.Core.Interfaces;
using LocalForecast53.Core.Validators;
using LocalForecast53.Shared.Helpers;
using Newtonsoft.Json;

namespace LocalForecast53.Application.Services
{
    public class ForecastServiceApp : IForecastServiceApp
    {
        private readonly IMapper _mapper;
        private readonly IService<CallHistory> _historyService;
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5";
        private string apiKey = "bdc71902dd52b3689449314887dd0df6";

        public ForecastServiceApp(IMapper mapper, IService<CallHistory> historyService)
        {
            _mapper = mapper;
            _historyService = historyService;
        }

        public Task<ForecastOutput> GetForecastAsync(ForecastInput forecastInput)
        {
            //1. Obter retornos da API externa (OpenWeather)
            var currentWeather = CallWeather(forecastInput);
            var data = CallForecast(forecastInput);

            //2. Mapear retorno com Output
            ForecastOutput forecastOutput = new ForecastOutput
            {
                Current = currentWeather,
                DataList = data
            };

            //3. Persistir os dados no banco
            var history = _mapper.Map<CallHistory>(forecastInput);
            history.SetResponseBody(currentWeather);
            _historyService.Add<CallHistory, CallHistoryValidator>(history);

            //4. Retornar Output
            return Task.FromResult(forecastOutput);
        }

        private string GetUnitString(Units units) => units switch
        {
            Units.Fahrenheit => "imperial",
            Units.Celsius => "metric",
            _ => throw new ArgumentOutOfRangeException(nameof(units), units, null)
        };

        private OpenWeatherData CallForecast(ForecastInput input)
        {
            using (var api = new APIHelper())
            {
                string url = $"{_baseUrl}/forecast?lat={input.Latitude}&lon={input.Longitude}&appid={apiKey}&units={GetUnitString(input.Unit)}";
                var result = api.GetAsync<OpenWeatherData>(url).Result;
                return result;
            }
        }

        private CurrentWeather CallWeather(ForecastInput input)
        {
            using (var api = new APIHelper())
            {
                string url = $"{_baseUrl}/weather?lat={input.Latitude}&lon={input.Longitude}&appid={apiKey}&units={GetUnitString(input.Unit)}";
                var result = api.GetAsync<CurrentWeather>(url).Result;
                return result;
            }
        }
    }
}

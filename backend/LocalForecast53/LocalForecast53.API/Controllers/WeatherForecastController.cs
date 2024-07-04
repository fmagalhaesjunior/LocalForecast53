using LocalForecast53.Application.Inputs;
using LocalForecast53.Application.Interfaces;
using LocalForecast53.Application.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace LocalForecast53.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : AbstractController<WeatherForecastController>
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastServiceApp _serviceApp;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastServiceApp serviceApp)
        {
            _logger = logger;
            _serviceApp = serviceApp;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [ProducesResponseType<ForecastOutput>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWeatherForecast([FromBody] ForecastInput forecastInput) =>
            Execute(() => _serviceApp.GetForecastAsync(forecastInput));
    }
}

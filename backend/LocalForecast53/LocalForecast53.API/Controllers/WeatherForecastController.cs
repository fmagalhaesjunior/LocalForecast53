using LocalForecast53.Application.External;
using LocalForecast53.Application.Inputs;
using LocalForecast53.Application.Interfaces;
using LocalForecast53.Application.Output;
using Microsoft.AspNetCore.Mvc;

namespace LocalForecast53.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : AbstractController<WeatherForecastController>
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastServiceApp _serviceApp;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastServiceApp serviceApp)
        {
            _logger = logger;
            _serviceApp = serviceApp;
        }

        [HttpPost(Name = "WeatherForecast")]
        [ProducesResponseType<ForecastOutput>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> WeatherForecast([FromBody] ForecastInput forecastInput) =>
            Execute(() => _serviceApp.GetForecastAsync(forecastInput));
    }
}

using LocalForecast53.Shared.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LocalForecast53.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ExternalApiSettings _settings;

        public ValuesController(IOptions<ExternalApiSettings> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_settings);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace LocalForecast53.API.Controllers
{
    public abstract class AbstractController<TController> : ControllerBase 
        where TController : AbstractController<TController>
    {
        protected IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Erro interno do serviço.");
            }
        }
    }
}

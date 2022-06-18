using Microsoft.AspNetCore.Mvc;

namespace PasswordGenerator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(123);
        }
    }
}
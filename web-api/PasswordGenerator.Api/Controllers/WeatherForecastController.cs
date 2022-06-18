using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Application;

namespace PasswordGenerator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IPasswordMetadataProvider _passwordMetadataProvider;

    public WeatherForecastController(IPasswordMetadataProvider passwordMetadataProvider)
    {
        _passwordMetadataProvider = passwordMetadataProvider;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_passwordMetadataProvider.ValidDuration);
    }
}
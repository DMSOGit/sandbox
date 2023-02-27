using Microsoft.AspNetCore.Mvc;
using Serilog;
using SwagTest.Model;

namespace SwagTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherClient _weatherClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherClient weatherClient)
        {
            _logger = logger;
            _weatherClient = weatherClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Log.Information("Calling Get");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("[action]")]
        public WeatherData GetWeatherData(string latitude = "45.51", string longitude = "-73.59")
        {
            return _weatherClient.GetWeatherData(latitude, longitude);
        }
    }
}
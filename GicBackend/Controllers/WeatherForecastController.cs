using GicBackend.Services.DbServices;
using Microsoft.AspNetCore.Mvc;

namespace GicBackend.Controllers
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
        private readonly IDbHelper _dbHelper;
        private readonly IDbSeeder _dbSeeder;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDbHelper dbHelper, IDbSeeder dbSeeder)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _dbSeeder = dbSeeder;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _dbSeeder.SetupEmployeeTable();
            _dbSeeder.SeedEmployeeTable();
            var result = _dbSeeder.TestSeedData();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

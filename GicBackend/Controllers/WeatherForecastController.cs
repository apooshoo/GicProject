using Autofac;
using GicBackend.DataObjects;
using GicBackend.Services.AutofacServices;
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            using (var scope = WeatherForecastRegistrar.GetModules(typeof(Cafe)))
            {
                var dbSeeder = scope.Resolve<IDbSeeder>();
                dbSeeder.SetupTable();
                dbSeeder.SeedTable();
                var result = dbSeeder.TestSeedData();
            }

            using (var scope = WeatherForecastRegistrar.GetModules(typeof(Employee)))
            {
                var dbSeeder = scope.Resolve<IDbSeeder>();
                dbSeeder.SetupTable();
                dbSeeder.SeedTable();
                var result = dbSeeder.TestSeedData();
            }

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

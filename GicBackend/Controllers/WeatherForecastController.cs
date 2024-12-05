using Autofac;
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
            var builder = new ContainerBuilder();
            builder.RegisterType<DbHelper>().As<IDbHelper>();
            builder.RegisterType<CafeSeeder>().As<IDbSeeder>();
            builder.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
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

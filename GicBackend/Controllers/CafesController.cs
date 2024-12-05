using Autofac;
using GicBackend.DataObjects;
using GicBackend.Services.AutofacServices;
using GicBackend.Services.CafeServices;
using GicBackend.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace GicBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CafesController : ControllerBase
    {
        private readonly ILogger<CafesController> _logger;

        public CafesController(ILogger<CafesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "cafes")]
        public IEnumerable<Cafe> Get(string? location)
        {
            List<Cafe> cafes;
            using (var scope = CafeRegistrar.GetModules())
            {
                var cafeProvider = scope.Resolve<ICafeProvider>();
                cafes = !string.IsNullOrEmpty(location)
                    ? cafeProvider.GetCafesByLocation(location)
                    : cafeProvider.GetAllCafes();
            }

            using (var scope = EmployeeRegistrar.GetModules())
            {
                var employeeProvider = scope.Resolve<IEmployeeProvider>();
                employeeProvider.GetEmployeeCountPerCafe(cafes);
            }


            return cafes;
        }
    }
}

using Autofac;
using GicBackend.DataObjects;
using GicBackend.Services.AutofacServices;
using GicBackend.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace GicBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<CafesController> _logger;

        public EmployeesController(ILogger<CafesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "employees")]
        public IEnumerable<Employee> Get(string? cafe)
        {
            List<Employee> employees;
            using (var scope = EmployeeRegistrar.GetModules())
            {
                var employeeProvider = scope.Resolve<IEmployeeProvider>();
                employees = !string.IsNullOrEmpty(cafe)
                    ? employeeProvider.GetEmployeeByCafe(cafe)
                    : employeeProvider.GetAllEmployees();
            }


            return employees;
        }
    }
}

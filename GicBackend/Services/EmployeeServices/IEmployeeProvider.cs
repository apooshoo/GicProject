using GicBackend.DataObjects;
using GicBackend.Services.DbServices;

namespace GicBackend.Services.EmployeeServices
{
    public interface IEmployeeProvider
    {
        IDbHelper _dbHelper { init; }

        void GetEmployeeCountPerCafe(IEnumerable<Cafe> cafes);
        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeeByCafe(string cafe_id);
    }
}
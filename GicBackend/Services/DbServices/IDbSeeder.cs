using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public interface IDbSeeder
    {
        int InsertEmployee(Employee employee);
        void InsertEmployees(IEnumerable<Employee> employees);
        void SeedEmployeeTable();
        void SetupEmployeeTable();
        List<Employee> TestSeedData();
    }
}
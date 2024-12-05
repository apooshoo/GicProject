using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public interface IDbSeeder
    {
        void SetupTable();
        void SeedTable();
        List<Employee> TestSeedData();
        void InsertCollection<T>(IEnumerable<T> employees);
    }
}
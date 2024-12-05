using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public interface IDbSeeder
    {
        void SetupTable();
        void SeedTable();
        int TestSeedData();
    }
}
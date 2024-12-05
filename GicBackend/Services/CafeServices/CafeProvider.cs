using GicBackend.DataObjects;
using GicBackend.Services.DbServices;

namespace GicBackend.Services.CafeServices
{
    public class CafeProvider : ICafeProvider
    {
        public required IDbHelper _dbHelper { protected get; init; }

        public List<Cafe> GetAllCafes()
        {
            using (_dbHelper.GetOpenConnection())
            {
                const string query = "SELECT id,name,description,location FROM Cafe";
                return _dbHelper.Query<Cafe>(query).ToList();
            }
        }

        public List<Cafe> GetCafesByLocation(string location)
        {
            using (_dbHelper.GetOpenConnection())
            {
                const string query = "SELECT id,name,description,location FROM Cafe WHERE location = @location";
                return _dbHelper.Query<Cafe>(query, new { location }).ToList();
            }
        }
    }
}

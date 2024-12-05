using GicBackend.DataObjects;
using GicBackend.Services.DbServices;

namespace GicBackend.Services.CafeServices
{
    public interface ICafeProvider
    {
        IDbHelper _dbHelper { init; }

        List<Cafe> GetAllCafes();
        List<Cafe> GetCafesByLocation(string location);
    }
}
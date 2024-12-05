
namespace GicBackend.Services.DbServices
{
    public interface IRecordInserter
    {
        IDbHelper _dbHelper { init; }

        void InsertCollection<T>(IEnumerable<T> cafes);
        int InsertSingle<T>(T record);
    }
}
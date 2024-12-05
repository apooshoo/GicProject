using Microsoft.Data.Sqlite;

namespace GicBackend.Services.DbServices
{
    public interface IDbHelper
    {
        SqliteConnection GetOpenConnection();
        int Execute(string query);
        int Execute(string query, object param);
        IEnumerable<T> Query<T>(string query);
    }
}
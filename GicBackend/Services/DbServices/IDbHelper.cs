using Microsoft.Data.Sqlite;

namespace GicBackend.Services.DbServices
{
    public interface IDbHelper
    {
        SqliteConnection GetOpenConnection();
        int Execute(string query);
        int Execute(string query, object param);
        int ExecuteScalar(string query, object param);
        IEnumerable<T> Query<T>(string query);
        IEnumerable<T> Query<T>(string query, object param);
    }
}
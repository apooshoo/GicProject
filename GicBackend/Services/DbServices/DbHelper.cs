using Dapper;
using Microsoft.Data.Sqlite;

namespace GicBackend.Services.DbServices
{
    public class DbHelper : IDbHelper
    {
        public required IConfiguration _config { protected get; init; }
        private SqliteConnection _con;

        private string ConnectionString
        {
            get => _config["ConnectionStrings:GicDB"] ?? throw new Exception("Error retrieving connection string.");
        }

        public SqliteConnection GetOpenConnection()
        {
            _con = new SqliteConnection(ConnectionString);
            _con.Open();
            return _con;
        }

        public int Execute(string query) => _con.Execute(query);
        public int Execute(string query, object param) => _con.Execute(query, param);
        public IEnumerable<T> Query<T>(string query) => _con.Query<T>(query);
    }
}

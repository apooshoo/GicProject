using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public class CafeSeeder : IDbSeeder
    {
        public required IDbHelper _dbHelper { protected get; init; }

        public void SetupTable()
        {
            // SQLite does not support IFs or IF-ELSE logic, so I will unconditionally drop the table and re-create to seed it (swallowing the error on the first run).
            // Otherwise I would use DROP TABLE IF EXISTS.

            DropTable();
            CreateTable();
        }

        public void SeedTable()
        {
            var cafes = new List<Cafe> {
                new Cafe { id = Guid.NewGuid().ToString(), name = "A", description = "AA", location = "AAA" },
                new Cafe { id = Guid.NewGuid().ToString(), name = "B", description = "BB", location = "BBB" },
                new Cafe { id = Guid.NewGuid().ToString(), name = "C", description = "CC", location = "CCC" },
                new Cafe { id = Guid.NewGuid().ToString(), name = "D", description = "DD", location = "DDD" },
            };

            InsertCollection(cafes);
        }

        public int TestSeedData()
        {
            using (_dbHelper.GetOpenConnection())
            {
                // Omit "id" as we are doing the computed column server-side instead of in the DB.
                var test = _dbHelper.Query<Cafe>("SELECT id,name,description,location FROM Cafe").ToList();
                return test.Count;
            }
        }

        public void InsertCollection<T>(IEnumerable<T> cafes)
        {
            // Manually insert due to SQLite limitations. Otherwise, I would use _con.BulkInsert.
            using (_dbHelper.GetOpenConnection())
            {
                foreach (T cafe in cafes)
                {
                    InsertSingle(cafe);
                }
            }
        }

        public int InsertSingle<T>(T record)
        {
            // Manually fill in params due to SQLite limitations.
            // Otherwise, I would use a generic _con.Insert<T>.
            const string query = @"
                INSERT INTO Cafe (id,name,description,location) 
                VALUES (@id,@name,@description,@location);";
            var cafe = record as Cafe;
            return _dbHelper.Execute(query, new { cafe.id, cafe.name, cafe.description, cafe.location });
        }

        private void DropTable()
        {
            try
            {
                using (_dbHelper.GetOpenConnection())
                {
                    _dbHelper.Execute("DROP TABLE Cafe");
                }
            }
            catch { }
        }

        private void CreateTable()
        {
            var query = @"
                CREATE TABLE Cafe (
	                id				VARCHAR(36) PRIMARY KEY, -- SQLite does not support UUID/Guid
	                name			NVARCHAR(10),
	                description		NVARCHAR(256),
	                location		NVARCHAR(256) 
                );   
            ";

            using (_dbHelper.GetOpenConnection())
            {
                _dbHelper.Execute(query);
            }
        }
    }
}

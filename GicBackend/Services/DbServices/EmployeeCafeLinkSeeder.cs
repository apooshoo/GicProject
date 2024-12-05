using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public class EmployeeCafeLinkSeeder : IDbSeeder
    {
        public required IDbHelper _dbHelper { protected get; init; }
        public required IRecordInserter _recordInserter { protected get; init; }

        public void SetupTable()
        {
            // SQLite does not support IFs or IF-ELSE logic, so I will unconditionally drop the table and re-create to seed it (swallowing the error on the first run).
            // Otherwise I would use DROP TABLE IF EXISTS.

            DropTable();
            CreateTable();
        }

        public void SeedTable()
        {
            var links = new List<EmployeeCafeLink> {
                new EmployeeCafeLink { employee_id = 1, cafe_id = SeedConstants.SeedGuid1.ToString(), start_date = DateTime.Now.AddDays(-1), end_date = DateTime.Now.AddDays(1) },
                new EmployeeCafeLink { employee_id = 2, cafe_id = SeedConstants.SeedGuid2.ToString(), start_date = DateTime.Now.AddDays(-2), end_date = DateTime.Now.AddDays(2) },
                new EmployeeCafeLink { employee_id = 3, cafe_id = SeedConstants.SeedGuid3.ToString(), start_date = DateTime.Now.AddDays(-3), end_date = null },
                new EmployeeCafeLink { employee_id = 4, cafe_id = SeedConstants.SeedGuid1.ToString(), start_date = DateTime.Now.AddDays(-4), end_date = null },
            };

            _recordInserter.InsertCollection(links);
        }

        public int TestSeedData()
        {
            using (_dbHelper.GetOpenConnection())
            {
                // Omit "id" as we are doing the computed column server-side instead of in the DB.
                var test = _dbHelper.Query<EmployeeCafeLink>("SELECT employee_id,cafe_id,start_date,end_date FROM EmployeeCafeLink").ToList();
                return test.Count;
            }
        }

        private void DropTable()
        {
            try
            {
                using (_dbHelper.GetOpenConnection())
                {
                    _dbHelper.Execute("DROP TABLE EmployeeCafeLink");
                }
            }
            catch { }
        }

        private void CreateTable()
        {
            const string query = @"
                CREATE TABLE EmployeeCafeLink (
	                employee_id INTEGER,
	                cafe_id VARCHAR(36),
	                start_date DATETIME,
	                end_date DATETIME
                );   
            ";

            using (_dbHelper.GetOpenConnection())
            {
                _dbHelper.Execute(query);
            }
        }
    }
}

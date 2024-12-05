using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public class EmployeeSeeder : IDbSeeder
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
            var employees = new List<Employee> {
                new Employee { name = "A", email_address = "AA", phone_number = "AAA", gender = "Male"  },
                new Employee { name = "B", email_address = "BB", phone_number = "BBB", gender = "Male"  },
                new Employee { name = "C", email_address = "CC", phone_number = "CCC", gender = "Male"  },
                new Employee { name = "D", email_address = "DD", phone_number = "DDD", gender = "Female"  },
            };

            _recordInserter.InsertCollection(employees);
        }

        public int TestSeedData()
        {
            using (_dbHelper.GetOpenConnection())
            {
                var test = _dbHelper.Query<Employee>("SELECT employee_id,name,email_address,phone_number,gender FROM Employee").ToList();
                return test.Count;
            }
        }

        private void DropTable()
        {
            try
            {
                using (_dbHelper.GetOpenConnection())
                {
                    _dbHelper.Execute("DROP TABLE Employee");
                }
            }
            catch { }
        }

        private void CreateTable()
        {
            const string query = @"
                CREATE TABLE Employee (
	                employee_id		INTEGER NOT NULL PRIMARY KEY,
	                id				NVARCHAR(9), -- Begins with 'UI', 9 chars  in total
	                name			NVARCHAR(10),
	                email_address	NVARCHAR(255),
	                phone_number	NVARCHAR(8), -- Starts with 8 or 9, has 8 digits
	                gender			NVARCHAR(10) -- Male/Female
                );   
            ";

            using (_dbHelper.GetOpenConnection())
            {
                _dbHelper.Execute(query);
            }
        }
    }
}

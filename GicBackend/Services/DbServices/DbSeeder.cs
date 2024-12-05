using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public class DbSeeder : IDbSeeder
    {
        private readonly IDbHelper _dbHelper;

        public DbSeeder(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public void SetupEmployeeTable()
        {
            // SQLite does not support IFs or IF-ELSE logic, so I will unconditionally drop the table and re-create to seed it (swallowing the error on the first run).
            // Otherwise I would use DROP TABLE IF EXISTS.

            DropEmployeesTable();
            CreateEmployeesTable();
        }

        public List<Employee> TestSeedData()
        {
            using (_dbHelper.GetOpenConnection())
            {
                // Omit "id" as we are doing the computed column server-side instead of in the DB.
                return _dbHelper.Query<Employee>("SELECT employee_id,name,email_address,phone_number,gender FROM Employee").ToList();
            }
        }

        public void SeedEmployeeTable()
        {
            var employees = new List<Employee> {
                new Employee { name = "A", email_address = "AA", phone_number = "AAA", gender = "Male"  },
                new Employee { name = "B", email_address = "BB", phone_number = "BBB", gender = "Male"  },
                new Employee { name = "C", email_address = "CC", phone_number = "CCC", gender = "Male"  },
                new Employee { name = "D", email_address = "DD", phone_number = "DDD", gender = "Female"  },
            };

            InsertEmployees(employees);
        }

        public void InsertEmployees(IEnumerable<Employee> employees)
        {
            // Manually insert due to SQLite limitations. Otherwise, I would use _con.BulkInsert.
            using (_dbHelper.GetOpenConnection())
            {
                foreach (Employee employee in employees)
                {
                    InsertEmployee(employee);
                }
            }
        }

        public int InsertEmployee(Employee employee)
        {
            // Manually fill in params due to SQLite limitations. Otherwise, I would use _con.Insert<Employee>.
            const string query = @"
                INSERT INTO Employee (name,email_address,phone_number,gender) 
                VALUES (@name,@email_address,@phone_number,@gender);";
            return _dbHelper.Execute(query, new { employee.name, employee.email_address, employee.phone_number, employee.gender });
        }

        private void DropEmployeesTable()
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

        private void CreateEmployeesTable()
        {
            var query = @"
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

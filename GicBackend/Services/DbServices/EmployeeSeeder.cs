﻿using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public class EmployeeSeeder : IDbSeeder
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
            var employees = new List<Employee> {
                new Employee { name = "A", email_address = "AA", phone_number = "AAA", gender = "Male"  },
                new Employee { name = "B", email_address = "BB", phone_number = "BBB", gender = "Male"  },
                new Employee { name = "C", email_address = "CC", phone_number = "CCC", gender = "Male"  },
                new Employee { name = "D", email_address = "DD", phone_number = "DDD", gender = "Female"  },
            };

            InsertCollection(employees);
        }

        public int TestSeedData()
        {
            using (_dbHelper.GetOpenConnection())
            {
                // Omit "id" as we are doing the computed column server-side instead of in the DB.
                var test = _dbHelper.Query<Employee>("SELECT employee_id,name,email_address,phone_number,gender FROM Employee").ToList();
                return test.Count;
            }
        }

        public void InsertCollection<T>(IEnumerable<T> employees)
        {
            // Manually insert due to SQLite limitations. Otherwise, I would use _con.BulkInsert.
            using (_dbHelper.GetOpenConnection())
            {
                foreach (T employee in employees)
                {
                    InsertSingle(employee);
                }
            }
        }

        private int InsertSingle<T>(T record)
        {
            // Manually fill in params due to SQLite limitations.
            // Otherwise, I would use a generic _con.Insert<T>.
            const string query = @"
                INSERT INTO Employee (name,email_address,phone_number,gender) 
                VALUES (@name,@email_address,@phone_number,@gender);";

            var employee = record as Employee;
            return _dbHelper.Execute(query, new { employee.name, employee.email_address, employee.phone_number, employee.gender });
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

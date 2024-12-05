using GicBackend.DataObjects;
using GicBackend.Services.DbServices;

namespace GicBackend.Services.EmployeeServices
{
    public class EmployeeProvider : IEmployeeProvider
    {
        public required IDbHelper _dbHelper { protected get; init; }

        public void GetEmployeeCountPerCafe(IEnumerable<Cafe> cafes)
        {
            // SQLite does not support table valued parameters,
            // otherwise I would have done this in bulk rather than per record.

            const string query = "SELECT COUNT(1) FROM EmployeeCafeLink WHERE cafe_id = @cafe_id";

            using (_dbHelper.GetOpenConnection())
            {
                foreach (var cafe in cafes)
                {
                    cafe.employees = _dbHelper.ExecuteScalar(query, new { cafe_id = cafe.id });
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            const string query = @"
                SELECT e.employee_id,e.name,e.email_address,e.phone_number,e.gender,
                    JULIANDAY(IFNULL(ecl.end_date, DATE('NOW'))) - JULIANDAY(ecl.start_date) AS days_worked,
                    c.name AS cafe
                FROM Employee e
                INNER JOIN EmployeeCafeLink ecl 
	                ON e.employee_id = ecl.employee_id
                INNER JOIN Cafe c
                    ON ecl.cafe_id = c.id;
            ";

            using (_dbHelper.GetOpenConnection())
            {
                return _dbHelper.Query<Employee>(query).ToList();
            }
        }

        public List<Employee> GetEmployeeByCafe(string cafe_id)
        {
            const string query = @"
                SELECT e.employee_id,e.name,e.email_address,e.phone_number,e.gender,
                    JULIANDAY(IFNULL(ecl.end_date, DATE('NOW'))) - JULIANDAY(ecl.start_date) AS days_worked,
                    c.name AS cafe
                FROM Employee e
                INNER JOIN EmployeeCafeLink ecl 
	                ON e.employee_id = ecl.employee_id
                INNER JOIN Cafe c
                    ON ecl.cafe_id = c.id
                WHERE ecl.cafe_id = @cafe_id;
            ";

            using (_dbHelper.GetOpenConnection())
            {
                return _dbHelper.Query<Employee>(query, new { cafe_id }).ToList();
            }
        }
    }
}

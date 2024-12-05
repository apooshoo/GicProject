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
    }
}

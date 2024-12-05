using GicBackend.DataObjects;

namespace GicBackend.Services.DbServices
{
    public class RecordInserter : IRecordInserter
    {
        public required IDbHelper _dbHelper { protected get; init; }

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
            // Manually fill in params according to type due to SQLite limitations.
            // Otherwise, I would use dapper ORM and do a generic Insert<T>.

            if (typeof(T) == typeof(Cafe))
            {
                const string query = @"
                    INSERT INTO Cafe (id,name,description,location) 
                    VALUES (@id,@name,@description,@location);";
                var cafe = record as Cafe;
                return _dbHelper.Execute(query, new { cafe.id, cafe.name, cafe.description, cafe.location });
            }
            else if (typeof(T) == typeof(Employee))
            {
                const string query = @"
                    INSERT INTO Employee (name,email_address,phone_number,gender) 
                    VALUES (@name,@email_address,@phone_number,@gender);";
                var employee = record as Employee;
                return _dbHelper.Execute(query, new { employee.name, employee.email_address, employee.phone_number, employee.gender });
            }
            else
            {
                throw new Exception("Invalid type specified.");
            }
        }
    }
}

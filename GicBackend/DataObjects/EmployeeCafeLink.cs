using System.ComponentModel.DataAnnotations.Schema;

namespace GicBackend.DataObjects
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Table("EmployeeCafeLink")]
    public class EmployeeCafeLink
    {
        [Column("employee_id")]
        public int employee_id { get; set; } 

        [Column("cafe_id")]
        public string cafe_id { get; set; } // SQLite does not support Guid, so I will use string for this exercise.

        [Column("start_date")]
        public DateTime start_date { get; set; }

        [Column("end_date")]
        public DateTime? end_date { get; set; }
    }
#pragma warning restore CS8618 // 
}

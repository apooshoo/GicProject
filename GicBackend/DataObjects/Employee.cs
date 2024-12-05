using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GicBackend.DataObjects
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Table("Employee")]
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long employee_id { get; set; }

        [Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string id
        {
            get
            {
                // Ideally I'd let the DB handle this as a computed column, but SQLite is being very finicky with computed columns so I'm going to do a workaround here for this assignment.
                // Would have definied the column type as: id AS 'UI' + RIGHT(CONCAT('000000000', employee_id), 7),
                const string prefix = "UI";
                const int numberLength = 7;
                var employee_idStr = employee_id.ToString();
                return prefix + string.Concat(Enumerable.Repeat('0', numberLength - employee_idStr.Length)) + employee_idStr;
            }
            set { id = value; }
        }

        [Column("name")]
        public string name { get; set; }

        [Column("email_address")]
        public string email_address { get; set; }

        [Column("phone_number")]
        public string phone_number { get; set; }

        [Column("gender")]
        public string gender { get; set; }
    }
#pragma warning restore CS8618 // 
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GicBackend.DataObjects
{
    [Table("Cafe")]
    public class Cafe
    {
        [Key]
        public string id { get; set; } // SQLite does not support Guid, so I will use string for this exercise.

        [Column("name")]
        public string name { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("location")]
        public string location { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GicBackend.DataObjects
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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

        [NotMapped]
        public int employees { get; set; }
    }
#pragma warning restore CS8618 // 
}

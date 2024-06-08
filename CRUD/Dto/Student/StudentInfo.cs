using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace SchoolManagementSystem.Dto.Student
{
    public class StudentInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Si { get; set; } // Serial primary key

        public DateTime Creation_on { get; set; }

        [MaxLength(40)]
        public string? Registration_id { get; set; } 

        [MaxLength(20)]
        public string? Id { get; set; }

        [MaxLength(250)]
        public string? Name { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        public int? Class { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public IEnumerable<string>?  Hobbie { get; set; }// Array of varchar(50)

        public string? Address { get; set; } // Text

        /* public  JObject ActivityLog { get; set; } */
        public string? Activity_log { get; set; }

        public char? Is_running { get; set; } // Array of char(1)

        public bool? Is_deleted { get; set; } // Boolean
    }
}

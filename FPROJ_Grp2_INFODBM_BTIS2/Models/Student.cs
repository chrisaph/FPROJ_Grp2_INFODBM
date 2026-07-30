using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Student
    {
        [Key]
        public string StudId { get; set; }

        public string LName { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }

        public int Did { get; set; }

        public int Ssid { get; set; }

        public int Aplid { get; set; }

        public string? Status { get; set; }
        public string? Remarks { get; set; }
        [Column("dob")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("hobbies")]
        public string? Hobbies { get; set; }
    }
}
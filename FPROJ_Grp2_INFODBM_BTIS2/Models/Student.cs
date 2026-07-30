using System.ComponentModel.DataAnnotations;

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
    }
}
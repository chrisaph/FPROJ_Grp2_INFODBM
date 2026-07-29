using System.ComponentModel.DataAnnotations;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Degree
    {
        [Key]
        public int Did { get; set; }

        public string DName { get; set; } = string.Empty;

        public int Sid { get; set; }
    }
}
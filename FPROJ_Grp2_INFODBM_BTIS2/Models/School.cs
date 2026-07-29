using System.ComponentModel.DataAnnotations;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class School
    {
        [Key]
        public int Sid { get; set; }

        public string SchoolName { get; set; } = string.Empty;
    }
}
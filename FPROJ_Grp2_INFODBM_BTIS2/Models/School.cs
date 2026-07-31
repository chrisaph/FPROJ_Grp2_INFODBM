using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class School
    {
        [Key]
        [Column("sid")]
        public int Sid { get; set; }

        [Column("school")]
        public string SchoolName { get; set; } = string.Empty;
    }
}
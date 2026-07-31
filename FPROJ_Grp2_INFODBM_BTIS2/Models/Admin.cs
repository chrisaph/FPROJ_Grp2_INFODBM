using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Admin
    {
        [Key]
        [Column("AdminID")]
        public int AdminID { get; set; }

        [Column("Username")]
        public string Username { get; set; } = string.Empty;

        [Column("Password")]
        public string Password { get; set; } = string.Empty;
    }
}
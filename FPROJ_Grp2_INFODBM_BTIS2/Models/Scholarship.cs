using System.ComponentModel.DataAnnotations;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Scholarship
    {
        [Key]
        public int Ssid { get; set; }

        public string SSType { get; set; } = string.Empty;
    }
}
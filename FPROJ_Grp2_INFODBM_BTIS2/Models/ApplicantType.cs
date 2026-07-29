using System.ComponentModel.DataAnnotations;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class ApplicantType
    {
        [Key]
        public int Aplid { get; set; }

        public string AplType { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Choice
    {
        [Key]
        public int Chid { get; set; }

        public string StudId { get; set; } = string.Empty;

        public string ChoiceName { get; set; } = string.Empty;

        public int Rank { get; set; }
    }
}
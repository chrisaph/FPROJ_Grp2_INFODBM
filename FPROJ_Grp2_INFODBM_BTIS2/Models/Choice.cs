using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Choice
    {
        [Key]
        [Column("chid")]
        public int Chid { get; set; }

        [Column("studid")]
        public string StudId { get; set; } = string.Empty;

        [Column("choice")]
        public string ChoiceName { get; set; } = string.Empty;

        [Column("rank")]
        public int Rank { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Portfolio
    {
        [Key]
        public string StudId { get; set; } = string.Empty;

        public string PortfolioLink { get; set; } = string.Empty;
    }
}
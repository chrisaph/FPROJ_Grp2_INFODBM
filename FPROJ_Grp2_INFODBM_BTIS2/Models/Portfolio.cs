using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class Portfolio
    {
        [Key]
        [Column("studid")]
        public string StudId { get; set; } = string.Empty;

        [Column("portfolio_link")]
        public string PortfolioLink { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPROJ_Grp2_INFODBM_BTIS2.Models
{
    public class ApplicantView
    {
        [Key]
        public string StudId { get; set; } = string.Empty;

        public string FName { get; set; } = string.Empty;

        public string MName { get; set; } = string.Empty;

        public string LName { get; set; } = string.Empty;

        public string Degree { get; set; } = string.Empty;

        public string School { get; set; } = string.Empty;

        public string Scholarship { get; set; } = string.Empty;

        public string ApplicantType { get; set; } = string.Empty;
        [Column("portfolio_link")]
        public string? PortfolioLink { get; set; }
        public string Status { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }
}
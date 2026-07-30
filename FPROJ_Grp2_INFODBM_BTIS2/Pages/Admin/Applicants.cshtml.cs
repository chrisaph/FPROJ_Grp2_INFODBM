using Microsoft.AspNetCore.Mvc.RazorPages;
using FPROJ_Grp2_INFODBM_BTIS2.Data;
using FPROJ_Grp2_INFODBM_BTIS2.Models;

namespace FPROJ_Grp2_INFODBM_BTIS2.Pages.Admin
{
    public class ApplicationsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicantView> Applicants { get; set; } = new();
        public void OnGet()
        {
            Applicants = _context.ApplicantViews.ToList();
        }
    }
}
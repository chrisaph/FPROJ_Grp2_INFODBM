using FPROJ_Grp2_INFODBM_BTIS2.Data;
using FPROJ_Grp2_INFODBM_BTIS2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("Login");
            }

            Applicants = _context.ApplicantViews.ToList();

            return Page();
        }
    }
}
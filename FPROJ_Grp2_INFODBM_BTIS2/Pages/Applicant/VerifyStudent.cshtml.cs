using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FPROJ_Grp2_INFODBM_BTIS2.Data;

namespace FPROJ_Grp2_INFODBM_BTIS2.Pages.Applicant
{
    public class VerifyStudentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VerifyStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string StudentId { get; set; }

        public string? ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var student = _context.Students
                .FirstOrDefault(s => s.StudId == StudentId);

            if (student == null)
            {
                ErrorMessage = "Student ID not found.";
                return Page();
            }

            return RedirectToPage("ApplicationForm",
                new { studid = StudentId });
        }
    }
}
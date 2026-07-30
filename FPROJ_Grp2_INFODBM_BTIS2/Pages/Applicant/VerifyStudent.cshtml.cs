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
            if (string.IsNullOrWhiteSpace(StudentId))
            {
                ModelState.AddModelError("StudentId", "Student ID is required.");
                return Page();
            }

            if (!int.TryParse(StudentId, out int id))
            {
                ModelState.AddModelError("StudentId", "Student ID must be numeric.");
                return Page();
            }

            if (id < 11000000 || id > 99100000)
            {
                ModelState.AddModelError("StudentId", "Student ID must be between 11000000 and 99100000.");
                return Page();
            }

            return RedirectToPage("/Applicant/AppForm", new { StudId = StudentId });
        }
    }
}
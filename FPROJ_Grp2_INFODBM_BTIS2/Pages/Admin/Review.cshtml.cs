using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FPROJ_Grp2_INFODBM_BTIS2.Data;
using FPROJ_Grp2_INFODBM_BTIS2.Models;

namespace FPROJ_Grp2_INFODBM_BTIS2.Pages.Admin
{
    public class ReviewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReviewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Student? Student { get; set; }

        public Portfolio? Portfolio { get; set; }

        public List<Choice> Choices { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; } = string.Empty;

        [BindProperty]
        public string Remarks { get; set; } = string.Empty;

        public void OnGet(string id)
        {
            Student = _context.Students
                .FirstOrDefault(s => s.StudId == id);

            if (Student == null)
                return;

            Portfolio = _context.Portfolios
                .FirstOrDefault(p => p.StudId == id);

            Choices = _context.Choices
                .Where(c => c.StudId == id)
                .OrderBy(c => c.Rank)
                .ToList();
        }

        public IActionResult OnPostApprove()
        {
            _context.Database.ExecuteSqlInterpolated($@"
        EXEC sp_ApproveApplicantTransaction
            @StudentID={Id},
            @Remarks={Remarks}");

            return RedirectToPage("Applicants");
        }

        public IActionResult OnPostWaitlist()
        {
            _context.Database.ExecuteSqlInterpolated($@"
        EXEC sp_WaitlistApplicantTransaction
            @StudentID={Id},
            @Remarks={Remarks}");

            return RedirectToPage("Applicants");
        }

        public IActionResult OnPostDecline()
        {
            _context.Database.ExecuteSqlInterpolated($@"
        EXEC sp_DeclineApplicantTransaction
            @StudentID={Id},
            @Remarks={Remarks}");

            return RedirectToPage("Applicants");
        }
    }
}
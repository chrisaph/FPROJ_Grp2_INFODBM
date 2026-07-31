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

        public Degree? Degree { get; set; }

        public Scholarship? Scholarship { get; set; }

        public ApplicantType? ApplicantType { get; set; }

        public IActionResult OnGet(string id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("Login");
            }

            Student = _context.Students
                .Include(s => s.Degree)
                    .ThenInclude(d => d.School)
                .Include(s => s.Scholarship)
                .Include(s => s.ApplicantType)
                .FirstOrDefault(s => s.StudId == id);

            if (Student == null)
            {
                return NotFound();   // or RedirectToPage("Applicants")
            }

            Portfolio = _context.Portfolios
                .FirstOrDefault(p => p.StudId == id);

            Choices = _context.Choices
                .Where(c => c.StudId == id)
                .OrderBy(c => c.Rank)
                .ToList();

            return Page();
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
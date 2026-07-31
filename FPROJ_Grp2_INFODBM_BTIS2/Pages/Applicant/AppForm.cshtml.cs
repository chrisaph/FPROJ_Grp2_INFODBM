using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPROJ_Grp2_INFODBM_BTIS2.Data;
using FPROJ_Grp2_INFODBM_BTIS2.Models;


namespace FPROJ_Grp2_INFODBM_BTIS2.Pages.Applicant
{
    public class AppFormModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AppFormModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string StudId { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public string PortfolioLink { get; set; } = string.Empty;

        [BindProperty]
        public string Choice1 { get; set; } = string.Empty;

        [BindProperty]
        public string Choice2 { get; set; } = string.Empty;

        [BindProperty]
        public string Choice3 { get; set; } = string.Empty;

        public List<SelectListItem> Degrees { get; set; } = new();

        public List<SelectListItem> Scholarships { get; set; } = new();

        public List<SelectListItem> Applicant_Type { get; set; } = new();

        public List<SelectListItem> Positions { get; set; } = new();

        public bool IsReadOnly =>
        Student != null &&
        (Student.Status == "Accepted" ||
         Student.Status == "Waitlisted");

        public void OnGet()
        {
            Degrees = _context.Degrees
            .Select(d => new SelectListItem
            {
                Value = d.Did.ToString(),
                Text = d.DName
            })
            .ToList();

            Scholarships = _context.Scholarships
                .Select(s => new SelectListItem
                {
                    Value = s.Ssid.ToString(),
                    Text = s.SSType
                })
                .ToList();

            Applicant_Type = _context.ApplicantTypes
                .Select(a => new SelectListItem
                {
                    Value = a.Aplid.ToString(),
                    Text = a.AplType
                })
                .ToList();

            Positions = new List<SelectListItem>
{
                    new SelectListItem { Text = "Photo", Value = "Photo" },
                    new SelectListItem { Text = "Writer", Value = "Writer" },
                    new SelectListItem { Text = "Layout", Value = "Layout" },
                    new SelectListItem { Text = "Video", Value = "Video" }
                };
            var existingStudent = _context.Students
            .FirstOrDefault(s => s.StudId == StudId);

            if (existingStudent != null)
            {
                Student = existingStudent;

                var portfolio = _context.Portfolios
                    .FirstOrDefault(p => p.StudId == StudId);

                PortfolioLink = portfolio?.PortfolioLink ?? "";

                var choices = _context.Choices
                    .Where(c => c.StudId == StudId)
                    .OrderBy(c => c.Rank)
                    .ToList();

                Choice1 = choices.ElementAtOrDefault(0)?.ChoiceName ?? "";
                Choice2 = choices.ElementAtOrDefault(1)?.ChoiceName ?? "";
                Choice3 = choices.ElementAtOrDefault(2)?.ChoiceName ?? "";
            }
            else
            {
                Student = new Student
                {
                    StudId = StudId
                };
            }
        }

        public IActionResult OnPost()
        {
            var student = _context.Students
    .FirstOrDefault(s => s.StudId == Student.StudId);

            if (student != null &&
                (student.Status == "Accepted" || student.Status == "Waitlisted"))
            {
                return Content("This application can no longer be edited.");
            }

            ModelState.Remove("Student.Status");
            ModelState.Remove("Student.Remarks");
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => $"{x.Key}: {string.Join(", ", x.Value.Errors.Select(e => e.ErrorMessage))}");

                return Content(string.Join("\n", errors));
            }


            if (!int.TryParse(Student.StudId, out int id) ||
            id < 11000000 ||
            id > 99100000)
            {
                ModelState.AddModelError("Student.StudId",
                    "Invalid Student ID Number.");

                OnGet(); // Reload dropdown lists
                return Page();
            }
            Console.WriteLine("2");
            // Default values
            Student.Status = "Pending";
            Student.Remarks = null;
            Student.StudId = Student.StudId.Trim();

           
            if (student == null)
            {
                // Student doesn't exist yet, so add a new one
                Student.Status = "Pending";
                Student.Remarks = null;

                _context.Students.Add(Student);
            }
            else
            {
                // Student already exists, so update it
                student.FName = Student.FName;
                student.MName = Student.MName;
                student.LName = Student.LName;
                student.Did = Student.Did;
                student.Ssid = Student.Ssid;
                student.Aplid = Student.Aplid;
                student.DateOfBirth = Student.DateOfBirth;
                student.Address = Student.Address;
                student.Email = Student.Email;
                student.Hobbies = Student.Hobbies;
                student.Status = "Pending";
                student.Remarks = null;
            }
            _context.SaveChanges();
            // Save Portfolio
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.StudId == Student.StudId);

            if (portfolio == null)
            {
                _context.Portfolios.Add(new Portfolio
                {
                    StudId = Student.StudId,
                    PortfolioLink = PortfolioLink
                });
            }
            else
            {
                portfolio.PortfolioLink = PortfolioLink;
            }

            // Save Choices
            var oldChoices = _context.Choices.Where(c => c.StudId == Student.StudId);
            _context.Choices.RemoveRange(oldChoices);

            _context.Choices.Add(new Choice
            {
                StudId = Student.StudId,
                ChoiceName = Choice1,
                Rank = 1
            });

            _context.Choices.Add(new Choice
            {
                StudId = Student.StudId,
                ChoiceName = Choice2,
                Rank = 2
            });

            _context.Choices.Add(new Choice
            {
                StudId = Student.StudId,
                ChoiceName = Choice3,
                Rank = 3
            });

            var entries = _context.ChangeTracker.Entries()
    .Select(e => new
    {
        Entity = e.Entity.GetType().Name,
        State = e.State
    })
    .ToList();

            try
{
    _context.SaveChanges();
    return RedirectToPage("/Applicant/Success");
}
catch (Exception ex)
{
    return Content(ex.ToString());
}


        }
    }
}

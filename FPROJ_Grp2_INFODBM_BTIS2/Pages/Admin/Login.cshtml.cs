using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FPROJ_Grp2_INFODBM_BTIS2.Data;

namespace FPROJ_Grp2_INFODBM_BTIS2.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public IActionResult OnPost()
        {
            var admin = _context.Admins.FirstOrDefault(a =>
                a.Username == Username &&
                a.Password == Password);

            if (admin == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            HttpContext.Session.SetString("Admin", admin.Username);

            return RedirectToPage("/Admin/Applicants");
        }
    }
}
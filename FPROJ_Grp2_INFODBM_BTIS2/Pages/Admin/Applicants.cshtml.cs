using Microsoft.AspNetCore.Mvc.RazorPages;
using FPROJ_Grp2_INFODBM_BTIS2.Data;
using FPROJ_Grp2_INFODBM_BTIS2.Models;

namespace FPROJ_Grp2_INFODBM_BTIS2.Pages.Admin;

public class ApplicantsModel : PageModel
{
    public void OnGet()
    {
        Students = _context.Students.ToList();
    }

    public List<Student> Students { get; set; } = new();

    private readonly ApplicationDbContext _context;

    public ApplicantsModel(ApplicationDbContext context)
    {
        _context = context;
    }

}
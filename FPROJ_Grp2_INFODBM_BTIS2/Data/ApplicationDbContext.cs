using FPROJ_Grp2_INFODBM_BTIS2.Models;
using Microsoft.EntityFrameworkCore;

namespace FPROJ_Grp2_INFODBM_BTIS2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Scholarship> Scholarships { get; set; }

        public DbSet<ApplicantType> ApplicantTypes { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
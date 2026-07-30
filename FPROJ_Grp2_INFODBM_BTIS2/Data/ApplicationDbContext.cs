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
        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Scholarship> Scholarships { get; set; }

        public DbSet<ApplicantType> ApplicantTypes { get; set; }

        public DbSet<ApplicantView> ApplicantViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table mappings
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Choice>().ToTable("Choices");
            modelBuilder.Entity<Portfolio>().ToTable("Portfolio");   // <-- THIS LINE
            modelBuilder.Entity<Degree>().ToTable("Degrees");
            modelBuilder.Entity<School>().ToTable("Schools");
            modelBuilder.Entity<Scholarship>().ToTable("Scholarships");
            modelBuilder.Entity<ApplicantType>().ToTable("Applicant_Type");

            // View mapping
            modelBuilder.Entity<ApplicantView>()
                .ToView("vw_Applicants");

            modelBuilder.Entity<ApplicantView>()
                .HasKey(a => a.StudId);
            modelBuilder.Entity<Choice>()
                .ToTable(tb => tb.HasTrigger("TR_MaxThreeChoices"));
        }


    }
}
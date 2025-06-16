using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<BearingIndicator> BearingIndicators { get; set; }

        public DbSet<SampleIndicator> SampleIndicators { get; set; }

        public DbSet<Indicator> Indicators { get; set; }

        public DbSet<Checkup> Checkups { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Hospital.API.Domain.Models;

namespace Hospital.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<FullPatient> Patient { get; set; }
        public DbSet<FullDoctor> Doctor { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<Medicine> Medicine { get; set; }

        public DbSet<PresMedicine> pres_medicine { get; set; }

        public DbSet<Disease> Disease { get; set; }

        public DbSet<Prescribtion> prescribtion { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Visit>()
            .HasKey(v => new { v.patient_id, v.vis_date });

            builder.Entity<PresMedicine>()
            .HasKey(p => new { p.med_name, p.pres_id });
        }
    }
}
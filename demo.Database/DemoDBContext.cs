using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using demo.Database.Entities;

namespace demo.Database
{
    public class DemoDBContext : IdentityDbContext<IdentityUser>
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seeding healthcare professional Master Data
            builder.Entity<HealthcareProfessional>().HasData(
                new HealthcareProfessional { Id = 1, Name = "Ashok Mahida", Title = "Mr", Specialty = "Ortho", CreatedBy =  1, CreatedOn = DateTime.Now, CreatedRoleId  = 1 },
                new HealthcareProfessional { Id = 2, Name = "Rahul Kansara", Title = "Mr", Specialty = "Heart", CreatedBy = 1, CreatedOn = DateTime.Now, CreatedRoleId = 1 },
                new HealthcareProfessional {Id = 3, Name = "Kevin Rathod", Title = "Mr", Specialty = "MD", CreatedBy = 1, CreatedOn = DateTime.Now, CreatedRoleId = 1 }
            );
        }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<HealthcareProfessional> HealthcareProfessional { get; set; }
    }
}

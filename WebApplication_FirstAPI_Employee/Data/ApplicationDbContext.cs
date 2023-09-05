using Microsoft.EntityFrameworkCore;
using WebApplication_FirstAPI_Employee.Models;

namespace WebApplication_FirstAPI_Employee.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganTrainee>()
                .HasKey(ot => new { ot.TraineeId, ot.OrganizationId });
            modelBuilder.Entity<OrganTrainee>()
                .HasOne(t => t.Trainee)
                .WithMany(ot => ot.OrganTrainees)
                .HasForeignKey(t => t.TraineeId);
            modelBuilder.Entity<OrganTrainee>()
                .HasOne(o => o.Organization)
                .WithMany(ot => ot.OrganTrainees)
                .HasForeignKey(o => o.OrganizationId);
        }
    }
}

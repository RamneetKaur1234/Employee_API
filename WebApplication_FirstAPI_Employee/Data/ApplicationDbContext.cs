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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee1> Employee1 { get; set; }
        public DbSet<Department1> Department1 { get; set; }
        public DbSet<DepartmentEmployee> DeptsEmps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional for 1:1
            //modelBuilder.Entity<Organization>()
            //    .HasOne(t => t.Trainee)
            //    .WithOne(t => t.Organization)
            //    .HasForeignKey<Trainee>(t =>t.OrgId)
            //    .IsRequired();
            //modelBuilder.Entity<Trainee>()
            //    .HasOne(o => o.Organization)
            //    .WithOne(t => t.Trainee)
            //    .HasForeignKey<Trainee>(ot => ot.OrgId)
            //    .IsRequired();

            // 1:M

            //modelBuilder.Entity<Department1>()
            //    .HasMany(d => d.Emp1)
            //    .WithOne(d => d.Departments1)
            //    .HasForeignKey(d => d.DepartmentId)
            //    .IsRequired();

            // M:M (Organization & Trainee)

            modelBuilder.Entity<OrganTraine>()
                .HasKey(ot => new { ot.TraineeId, ot.OrganizationId });
            modelBuilder.Entity<OrganTraine>()
                .HasOne(t => t.Trainee)
                .WithMany(ot => ot.OrganTraines)
                .HasForeignKey(t => t.TraineeId);
            modelBuilder.Entity<OrganTraine>()
                .HasOne(o => o.Organization)
                .WithMany(ot => ot.OrganTraines)
                .HasForeignKey(o => o.OrganizationId);

            // M:M (Department & Employee)
            modelBuilder.Entity<DepartmentEmployee>()
                .HasKey(x => new { x.EmployeeId, x.DepartmentId });
            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(x => x.Employees1)
                .WithMany(x => x.DeptEmp)
                .HasForeignKey(x => x.EmployeeId);
            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(x => x.Departments1)
                .WithMany(x => x.DeptEmp)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}

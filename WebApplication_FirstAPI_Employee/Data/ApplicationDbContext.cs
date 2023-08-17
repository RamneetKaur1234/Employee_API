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
        public DbSet<User> Users { get; set; }

    }
}

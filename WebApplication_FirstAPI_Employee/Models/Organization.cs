using System.ComponentModel.DataAnnotations;
using WebApplication_FirstAPI_Employee.Repository;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<OrganTraine> OrganTraines { get; set; }
    }
}

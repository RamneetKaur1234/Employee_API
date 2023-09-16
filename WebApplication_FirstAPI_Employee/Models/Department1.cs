using System.ComponentModel.DataAnnotations;
using WebApplication_FirstAPI_Employee.Models.DTOs;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class Department1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee1> Emp1 { get; set; } = new List<Employee1>();
        public ICollection<DepartmentEmployee> DeptEmp { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class Employee1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string EMail { get; set; }
        public ICollection<DepartmentEmployee> DeptEmp { get; set; }
    }
}

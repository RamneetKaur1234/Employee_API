namespace WebApplication_FirstAPI_Employee.Models
{
    public class DepartmentEmployee
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public Department1 Departments1 { get; set; }
        public Employee1 Employees1 { get; set; }
    }
}

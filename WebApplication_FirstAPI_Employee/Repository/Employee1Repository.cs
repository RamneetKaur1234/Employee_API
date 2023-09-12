using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class Employee1Repository:Repository<Employee1>,IEmployee1Repository
    {
        public Employee1Repository(ApplicationDbContext context):base(context)
        {
        }

        public bool CreateEmployee(int deptId, Employee1 employee)
        {
            var department = _context.Department1.Where(d => d.Id == deptId).FirstOrDefault();
            var deptEmp = new DepartmentEmployee()
            {                
                Departments1 = department,
                Employees1 = employee,
            };
            _context.Add(employee);
            _context.Add(deptEmp);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateEmployee(int newdeptId, int olddeptId, Employee1 employee)
        {
                var employeeDepartmentFromDb = _context.DeptsEmps.FirstOrDefault(x => x.EmployeeId == employee.Id &&
                                                                                                 x.DepartmentId == olddeptId);
                if (newdeptId == olddeptId)
                    _context.Update(employeeDepartmentFromDb);
                else
                {
                    _context.Remove(employeeDepartmentFromDb);
                    var department = _context.Department1.FirstOrDefault(x => x.Id == newdeptId);
                    var employeeDepartment = new DepartmentEmployee()
                    {
                        Departments1 = department,
                        Employees1 = employee
                    };
                    _context.Add(employeeDepartment);
                }
                _context.Update(employee);
                return Save();
        }
    }
}

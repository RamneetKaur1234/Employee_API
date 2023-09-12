using WebApplication_FirstAPI_Employee.Models;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IEmployee1Repository:IRepository<Employee1>
    {
        bool CreateEmployee(int deptId ,Employee1 employee);
        bool UpdateEmployee(int newdeptId,int  olddeptId ,Employee1 employee);
        bool Save();
    }
}

using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class Department1Repository:Repository<Department1>,IDepartment1Repository
    {
        public Department1Repository(ApplicationDbContext context):base(context)
        {            
        }
    }
}

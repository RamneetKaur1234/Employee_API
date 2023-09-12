using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}

using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class TraineeRepository:Repository<Trainee>,ITraineeRepository
    {
        public TraineeRepository(ApplicationDbContext context) : base(context)
        {
                
        }
    }
}

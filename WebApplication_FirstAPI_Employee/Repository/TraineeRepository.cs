using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class TraineeRepository : Repository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

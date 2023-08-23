using System.Data;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        ITraineeRepository Trainee { get; }
        int Save();
        IDbTransaction BeginTransaction();
    }
}

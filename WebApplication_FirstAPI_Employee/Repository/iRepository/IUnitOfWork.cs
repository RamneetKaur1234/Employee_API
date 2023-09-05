using System.Data;

namespace WebApplication_FirstAPI_Employee.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        ITraineeRepository Trainee { get; }
        IUserRepository User { get; }
        IOrganizationRepository Organization { get; }
        int Save();
        IDbTransaction BeginTransaction();
    }
}

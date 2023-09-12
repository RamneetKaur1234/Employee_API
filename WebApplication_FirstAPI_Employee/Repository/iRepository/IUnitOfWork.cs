using System.Data;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        ITraineeRepository Trainee { get; }
        IUserRepository User { get; }
        IOrganizationRepository Organization { get; }
        IDepartmentRepository Department { get; }
        IDepartment1Repository Department1 { get; }
        IEmployee1Repository Employee1 { get; }
        int Save();
        IDbTransaction BeginTransaction();
    }
}

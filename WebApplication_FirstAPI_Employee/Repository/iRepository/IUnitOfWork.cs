namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        ITraineeRepository Trainee { get; }
        int Save();
    }
}

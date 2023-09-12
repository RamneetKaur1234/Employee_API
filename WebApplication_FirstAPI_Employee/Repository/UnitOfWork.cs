using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appsettings;

        public UnitOfWork(ApplicationDbContext context,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appsettings = appSettings.Value;
            Employee = new EmployeeRepository(context);
            Trainee = new TraineeRepository(context);
            User = new UserRepository(context,appSettings);
            Organization=new OrganizationRepository(context);
            Department =new DepartmentRepository(context);
            Department1 = new Department1Repository(context);
            Employee1 = new Employee1Repository(context);
        }

        public IEmployeeRepository Employee { get; private set; }   
        public ITraineeRepository Trainee { get; private set; }
        public IUserRepository User { get; private set; }
        public IOrganizationRepository Organization { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IDepartment1Repository Department1 { get; private set; }
        public IEmployee1Repository Employee1 { get; private set; }



        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //}

        public int Save()
        {
            return _context.SaveChanges();
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }
    }
}

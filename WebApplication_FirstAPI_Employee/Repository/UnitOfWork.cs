using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

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
            Organization = new OrganizationRepository(context);
        }

        public IEmployeeRepository Employee { get; private set; }   
        public ITraineeRepository Trainee { get; private set; }
        public IUserRepository User { get; private set; }

        public IOrganizationRepository Organization { get; private set; }


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

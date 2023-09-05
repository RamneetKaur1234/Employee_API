using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class OrganizationRepository:Repository<Organization>,IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context):base (context)
        {
            _context = context; 
        }
        public bool CreateOrganization(int traineeId, Organization organization)
        {
            //_context.Organizations.Add(organization);
            //return Save();
            var trainee = _context.Trainees.Where(o => o.Id == traineeId).FirstOrDefault();
            var traineeOrgan = new OrganTrainee()
            {
                Organization = organization,
                Trainee =trainee 
            };            _context.Add(organization);

            _context.Add(traineeOrgan);
            return Save();
        }

        //public ICollection<Organization> GetAll()
        //{
        //    return _context.Organizations.ToList();
        //}

        public bool Save()
        {
            var emp = _context.SaveChanges();
           return emp > 0 ? true : false;
        }
    }
}

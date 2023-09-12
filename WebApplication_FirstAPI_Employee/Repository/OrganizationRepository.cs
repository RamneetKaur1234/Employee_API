using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class OrganizationRepository:Repository<Organization>,IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context):base(context)
        {
                _context=context;
        }

        public bool CreateOrganization(int traineeId, Organization organization)
        {
            var trainee = _context.Trainees.Where(o => o.Id == traineeId).FirstOrDefault();
            var traineeOrgan = new OrganTraine()
            {
                Organization = organization,
                Trainee = trainee
            };
            _context.Add(organization);
            _context.Add(traineeOrgan);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0?true:false;
        }
    }
}

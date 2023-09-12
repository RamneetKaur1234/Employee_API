using WebApplication_FirstAPI_Employee.Models;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IOrganizationRepository:IRepository<Organization>
    {
        bool CreateOrganization(int traineeId, Organization organization);
        bool Save();
    }
}
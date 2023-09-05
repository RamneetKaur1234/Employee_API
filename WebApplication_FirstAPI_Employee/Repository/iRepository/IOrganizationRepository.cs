using AutoMapper;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

namespace WebApplication_FirstAPI_Employee.Repository.IRepository
{
    public interface IOrganizationRepository:IRepository<Organization>
    {
        //ICollection<Organization> GetAll();
        bool CreateOrganization(int traineeId,Organization organization);
        bool Save();
    }
}

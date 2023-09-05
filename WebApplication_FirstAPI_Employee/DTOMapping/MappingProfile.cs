using AutoMapper;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;

namespace WebApplication_FirstAPI_Employee.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            CreateMap<TraineeDTO, Trainee>();
            CreateMap<Trainee, TraineeDTO>();
        }
    }
}

using AutoMapper;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository;

namespace WebApplication_FirstAPI_Employee.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            CreateMap<Trainee, TraineeDTO>();
            CreateMap<TraineeDTO, Trainee>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO,Department>();
            CreateMap<Employee1DTO, Employee1>();
            CreateMap<Employee1, Employee1DTO>();
            CreateMap<Department1DTO, Department1>();
            CreateMap<Department1, Department1DTO>();
        }
    }
}

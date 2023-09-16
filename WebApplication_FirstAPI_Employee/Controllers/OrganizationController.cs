using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/organization")]
    [ApiController]
    [Authorize]
    public class OrganizationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrganizationController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetOrganizations()
        {
            var organ = _unitOfWork.Organization.GetAll();
            var organizations = _mapper.Map<List<OrganizationDTO>>(organ);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(organizations);
        }
        [HttpPost]
        public IActionResult CreateOrganization([FromQuery] int traineeId, [FromBody] OrganizationDTO organizationDto)
        {
            if (organizationDto == null) return BadRequest();
            var organizations = _unitOfWork.Organization.FirstorDefault(o => o.Name == organizationDto.Name);
            if (organizations != null)
            {
                ModelState.AddModelError("", "Organization Already Exists...!!");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest();
            var organMap = _mapper.Map<Organization>(organizationDto);
            if (!_unitOfWork.Organization.CreateOrganization(traineeId, organMap))
            {
                ModelState.AddModelError("", "Smthng Went Wrng While Save Data...!!");
                return StatusCode(500, ModelState);
            }
            return Ok("Data Saved SuccessFully...!!");
        }
        [HttpPut]
        public IActionResult UpdateOrganization([FromBody] OrganizationDTO organizationDto)
        {
            if (organizationDto == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            var organMap = _mapper.Map<Organization>(organizationDto);
            _unitOfWork.Organization.Update(organMap);
            _unitOfWork.Save();
            return Ok ("Data Updated Successfully...!!");
        }
        [HttpDelete]
        public IActionResult DeleteOrganization(int id)
        {
            var organization = _unitOfWork.Organization.Find(id);
            var organi=_mapper.Map<Organization>(organization);
            _unitOfWork.Organization.Delete(organi);
            _unitOfWork.Save();
            return Ok("Data Deleted Successfully...!!");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      //  private readonly IOrganizationRepository _organizationRepository;
        public OrganizationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           // _organizationRepository = organizationRepository;
        }

        [HttpGet]

        public IActionResult GetOrganization()
        {
            var organizations = _mapper.Map<List<OrganizationDTO>>(_unitOfWork.Organization.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var organizationList = _organizationRepository.GetAll()
            //    .ToList()
            //    .Select(_mapper.Map<Organization, OrganizationDTO>);
            return Ok(organizations);
        }
        [HttpPost]
        public IActionResult CreateOrganization([FromQuery] int trainId, [FromBody] OrganizationDTO createOrganization)
        {
            if (createOrganization == null) return BadRequest(ModelState);
            var organizations = _unitOfWork.Organization.FirstorDefault(o => o.Name == createOrganization.Name);
            if (organizations != null)
            {
                ModelState.AddModelError("", "Organization Already Exists...!!");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var organMap = _mapper.Map<Organization>(createOrganization);

            if (!_unitOfWork.Organization.CreateOrganization(trainId, organMap))
            {
                ModelState.AddModelError("", "Smthng Went Wrng While Save Data...!!");
                return StatusCode(500, ModelState);
            }
            return Ok("Data Saved SuccessFully...!!");
        }
    }
}

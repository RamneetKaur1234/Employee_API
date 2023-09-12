using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDepartment()
        {
            var getdepartment = _mapper.Map<DepartmentDTO>(_unitOfWork.Department.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(getdepartment);
        }
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var  depts =_mapper.Map<Department>(departmentDTO);
            _unitOfWork.Department.Add(depts);
            _unitOfWork.Save();
            return Ok("Data Saved SuccessFully...!!");
        }
        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            var depts = _mapper.Map<Department>(departmentDTO);
            _unitOfWork.Department.Update(depts);
            _unitOfWork.Save();
            return Ok("Data Updated SuccessFully...!!");
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _unitOfWork.Department.Find(id);
            var depts = _mapper.Map<Department>(department);
            _unitOfWork.Department.Delete(depts);
            _unitOfWork.Save();
            return Ok("Data Deleted SuccessFully...!!");
        }
    }
}

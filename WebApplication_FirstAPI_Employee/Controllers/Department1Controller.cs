using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/department1")]
    [ApiController]
    public class Department1Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Department1Controller(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        [HttpGet]
        public IActionResult GetDepartment()
        {
            var department = _unitOfWork.Department1.GetAll();
            var dept=_mapper.Map<List<Department1DTO>>(department);
            //foreach (var dept in department)
            //{
            //    var emp1 = _mapper.Map<List<Employee1DTO>>(_unitOfWork.Employee1.GetAll(x => x.DepartmentId == dept.Id));
            //}
            return Ok(department);
        }
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department1DTO departmentDto)
        {
            if (departmentDto == null) return BadRequest();
            var departments = _unitOfWork.Department1.FirstorDefault(o => o.Name == departmentDto.Name);
            if (departments != null)
            {
                ModelState.AddModelError("", "Department Already Exists...!!");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest();
            var deptMap = _mapper.Map<Department1>(departmentDto);
            _unitOfWork.Department1.Add(deptMap);
            _unitOfWork.Save();
            return Ok("Data Saved Successfully...!!");
        }
        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] Department1DTO departmentDto)
        {
            if (departmentDto == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            var deptMap = _mapper.Map<Department1>(departmentDto);
            _unitOfWork.Department1.Update(deptMap);
            _unitOfWork.Save();
            return Ok("Data Updated Successfully...!!");
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _unitOfWork.Department1.Find(id);
            var dept=_mapper.Map<Department1>(department);
            _unitOfWork.Department1.Delete(dept);
            _unitOfWork.Save();
            return Ok("Data Deleted Successfully...!!");
        }
    }
}

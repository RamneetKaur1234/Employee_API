using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/employee1")]
    [ApiController]
    public class Employee1Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Employee1Controller(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            var emp = _unitOfWork.Employee1.GetAll();
            var empList = _mapper.Map<List<Employee1DTO>>(emp);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(empList);
        }
        [HttpPost]
        public IActionResult CreateEmployee([FromQuery] int deptId,[FromBody] Employee1DTO employeeDto)
        {
            if(employeeDto==null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var emp = _mapper.Map<Employee1>(employeeDto);
            if(!_unitOfWork.Employee1.CreateEmployee(deptId,emp))
            {
                ModelState.AddModelError("", "Smthng Went Wrng While Save Data...!!");
                return StatusCode(500, ModelState);
            }
            return Ok("Data Saved SuccessFully...!!");
        }
        [HttpPut]
        //public IActionResult UpdateEmployee([FromQuery] int newdeptId, int olddeptId, [FromBody] Employee1DTO employeeDto)
        //{
        //    if (employeeDto == null) return BadRequest();
        //    if (!ModelState.IsValid) return BadRequest();
        //    var emp = _mapper.Map<Employee1>(employeeDto);
        //    if (!_unitOfWork.Employee1.UpdateEmployee(newdeptId,olddeptId, emp))
        //    {
        //        ModelState.AddModelError("", "Smthng Went Wrng While Save Data...!!");
        //        return StatusCode(500, ModelState);
        //    }
        //    return Ok("Data Updated SuccessFully...!!");
        //}
        public IActionResult UpdateEmployee([FromBody] Employee1DTO employeeDTO)
        {
            if (employeeDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var emp = _mapper.Map<Employee1>(employeeDTO);
            _unitOfWork.Employee1.Update(emp);
            _unitOfWork.Save();
            return Ok("Data Updated SuccessFully...!!");
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employInDb = _unitOfWork.Employee1.Find(id);
            var emp = _mapper.Map<Employee1>(employInDb);
            _unitOfWork.Employee1.Delete(emp);
            _unitOfWork.Save();
            return Ok("Data Deleted SuccessFully...!!");
        }

    }
}

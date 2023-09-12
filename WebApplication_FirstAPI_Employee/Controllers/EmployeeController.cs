using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/employee")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employeeList =  _unitofwork.Employee.GetAll();
            if (employeeList == null)
            {
                return NotFound();
            }
            return Ok(employeeList);
        }

        [HttpGet("{EmployeeId:int}")]
        public async Task<IActionResult> GetEmployeeById(int EmployeeId)
        {
            var employeeDetails = await _unitofwork.Employee.Get(EmployeeId);
            if (employeeDetails != null)
            {
                return Ok(employeeDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] List<Employee> employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var employ=_mapper.Map<Employee>(employee);
            _unitofwork.Employee.Add(employ);
            _unitofwork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] List<Employee> employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var employ = _mapper.Map<Employee>(employee);
            _unitofwork.Employee.Update(employ);
            _unitofwork.Save();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _unitofwork.Employee.Find(id);
            //if (employeeInDb == null) return NotFound();
            var employ = _mapper.Map<Employee>(employeeInDb);
            _unitofwork.Employee.Delete(employ);
            _unitofwork.Save();
            return Ok();
        }

    }
}

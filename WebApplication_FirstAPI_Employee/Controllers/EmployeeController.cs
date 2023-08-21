using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        [Authorize(Roles = "Employee,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employeeList = await _unitofwork.Employee.GetAll();
            if (employeeList == null)
            {
                return NotFound();
            }
            return Ok(employeeList);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitofwork.Employee.Add(employee);
            _unitofwork.Save();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitofwork.Employee.Update(employee);
            _unitofwork.Save();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _unitofwork.Employee.Find(id);
            if (employeeInDb == null) return NotFound();
            _unitofwork.Employee.Delete(employeeInDb);
            _unitofwork.Save();
            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

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
        [Authorize(Roles = "Admin")]
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
        public IActionResult CreateEmployee([FromBody] List<Employee> employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitofwork.BeginTransaction();
            try
            {
                foreach (var employ in employee)
                {
                    if (employ.Name=="")
                    {
                        throw new Exception("Name Can't Be Empty...!!");
                    }
                    _unitofwork.Employee.Add(employ);
                    _unitofwork.Save();
                }
                transaction.Commit();
            }
            catch (Exception exc)
            {
                transaction.Rollback();
                return StatusCode(404, exc.Message);
            }                      
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] List<Employee> employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitofwork.BeginTransaction();
            try
            {
                foreach (var employ in employee)
                {
                    if(employ.Name=="")
                    {
                        throw new Exception("Name Can't Be Empty...!!");
                    }
                    _unitofwork.Employee.Update(employ);
                    _unitofwork.Save();
                }
                transaction.Commit();
            }
            catch (Exception exc)
            {
                transaction.Rollback();
                return StatusCode(404, exc.Message);
            }           
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int[] ids)
        {
            using var transaction= _unitofwork.BeginTransaction();
            try
            {
                foreach (var id in ids)
                {
                    var employeeInDb = _unitofwork.Employee.Find(id);
                    //if (employeeInDb == null) return NotFound();
                    _unitofwork.Employee.Delete(employeeInDb);
                    _unitofwork.Save();
                }
                transaction.Commit();
            }
            catch (Exception exc)
            {
                transaction.Rollback();
                return StatusCode(404, exc.Message);
            }           
            return Ok();
        }

    }
}

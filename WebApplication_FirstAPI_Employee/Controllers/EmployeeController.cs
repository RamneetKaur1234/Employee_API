using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
                _context = context;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList());
        }
        [HttpPost]
        public IActionResult SaveEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var employeeDb = _context.Employees.ToList().Where(x => x.EMail == employee.EMail).FirstOrDefault();
            if(employeeDb==null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            else
            {
                return StatusCode(404, "Email In Use...!!");
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if(employee==null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var employeeInDb=_context.Employees.AsNoTracking().Where(x=>x.EMail== employee.EMail && x.Id==employee.Id).FirstOrDefault();
            var employeeInDb2=_context.Employees.AsNoTracking().Where(x=>x.EMail== employee.EMail && x.Id!=employee.Id).FirstOrDefault();

            if(employeeInDb==null && employeeInDb2!=null)
            {
                return StatusCode(404, "Email Already Existed In DB...!!");
            }
            else
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.Find(id);
            if (employeeInDb == null) return NotFound();
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/trainee")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public TraineeController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        [Authorize(Roles = "Trainee,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetTraineeList()
        {
            var traineeList = await _unitofwork.Trainee.GetAll();
            if (traineeList == null)
            {
                return NotFound();
            }
            return Ok(traineeList);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{TraineeId:int}")]
        public async Task<IActionResult> GetTraineeById(int TraineeId)
        {
            var traineeDetails = await _unitofwork.Trainee.Get(TraineeId);
            if (traineeDetails != null)
            {
                return Ok(traineeDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateTrainee([FromBody] Trainee trainee)
        {
            if (trainee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitofwork.Trainee.Add(trainee);
            _unitofwork.Save();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateTrainee([FromBody] Trainee trainee)
        {
            if (trainee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitofwork.Trainee.Update(trainee);
            _unitofwork.Save();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTrainee(int id)
        {
            var traineeInDb = _unitofwork.Trainee.Find(id);
            if (traineeInDb == null) return NotFound();
            _unitofwork.Trainee.Delete(traineeInDb);
            _unitofwork.Save();
            return Ok();
        }
    }
}

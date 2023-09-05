using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Repository.IRepository;

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

        [Authorize(Roles = "Admin")]
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
        public IActionResult CreateTrainee([FromBody] List<Trainee> trainee)
        {
            if (trainee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitofwork.BeginTransaction();
            try
            {
                foreach (var train in trainee)
                {
                    if(train.Name=="")
                    {
                        throw new Exception("Name Can't Be Empty...!!");
                    }
                    _unitofwork.Trainee.Add(train);
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
        public IActionResult UpdateTrainee([FromBody] List<Trainee> trainee)
        {
            if (trainee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitofwork.BeginTransaction();
            try
            {
                foreach (var train in trainee)
                {
                    if(train.Name=="")
                    {
                        throw new Exception("Name Can't Be Empty...!!");
                    }
                    _unitofwork.Trainee.Update(train);
                    _unitofwork.Save();
                }
                transaction.Commit();
            }
            catch (Exception exc)
            {
                transaction.Rollback();
                return StatusCode(404,exc.Message);
            }            
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteTrainee(int[] ids)
        {
            using var transaction= _unitofwork.BeginTransaction();
            try
            {
                foreach (var id in ids)
                {
                    var traineeInDb = _unitofwork.Trainee.Find(id);
                    //if (traineeInDb == null) return NotFound();
                    _unitofwork.Trainee.Delete(traineeInDb);
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

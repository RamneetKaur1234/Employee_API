using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.DTOs;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/trainee")]
    [ApiController]
    [Authorize]
    public class TraineeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public TraineeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTraineeList()
        {
            var train = _unitofwork.Trainee.GetAll();
            var traineeList =  _mapper.Map<List<TraineeDTO>>(train);
            if (traineeList == null) return NotFound();
            return Ok(traineeList);
        }

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
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateTrainee(int orgId,[FromBody] TraineeDTO trainee)
        {
            if (trainee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var train = _mapper.Map<Trainee>(trainee);
            _unitofwork.Trainee.Add(train);
            _unitofwork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTrainee([FromBody] TraineeDTO trainee)
        {
            if (trainee == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            var train = _mapper.Map<Trainee>(trainee);
            _unitofwork.Trainee.Update(train);
            _unitofwork.Save();               
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTrainee(int id)
        {
            var traineeInDb = _unitofwork.Trainee.Find(id);
            var traine = _mapper.Map<Trainee>(traineeInDb);
            if (traineeInDb == null) return NotFound();
            _unitofwork.Trainee.Delete(traine);
            _unitofwork.Save();
            return Ok();
        }
    }
}

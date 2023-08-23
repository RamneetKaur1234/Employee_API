using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.ViewModels;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitofwork;
        public UserController(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitofwork= unitOfWork;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] List<UserVModel2> users)
        {
            using var transaction=_unitofwork.BeginTransaction();
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var user in users)
                    {
                        var isUniqueUser = _userRepository.IsUniqueUser(user);
                        if (!isUniqueUser)
                            return BadRequest("User In Use...!!");
                        var userInfo = _userRepository.Register(user);
                        if (userInfo == null) return BadRequest();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception exc)
            {
                transaction.Rollback();
                return StatusCode(404,exc.Message);
            }            
            return Ok();
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]UserVM userVM)
        {
            var user = _userRepository.Autenticate(userVM.Username, userVM.Password);
            if (user == null) return BadRequest("Wrong User & Pswrd...!!");
            return Ok(user);
        }
    }
}

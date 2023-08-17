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
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                var isUniqueUser = _userRepository.IsUniqueUser(user.Username);
                if (!isUniqueUser)
                    return BadRequest("User In Use...!!");
                var userInfo = _userRepository.Register(user.Username,user.Password,user.ConfirmPassword,user.Role);
                if (userInfo == null) return BadRequest(); 
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

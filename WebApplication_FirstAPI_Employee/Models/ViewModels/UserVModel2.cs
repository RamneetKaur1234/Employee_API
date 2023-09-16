using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models.ViewModels
{
    public class UserVModel2
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}

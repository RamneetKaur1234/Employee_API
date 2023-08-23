using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models.ViewModels
{
    public class UserVModel2
    {
        [Required(ErrorMessage = "This Field is Required...!!")]
        public string UserName { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter," +
           " one lowercase letter," +
           " one digit and one special character...!!")]
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "This Field is Required...!!")]
        public string Role { get; set; }
    }
}

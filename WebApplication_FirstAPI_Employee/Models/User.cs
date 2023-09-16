using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
       
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public string Role { get; set; }
    }
}

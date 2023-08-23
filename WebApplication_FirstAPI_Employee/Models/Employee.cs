using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "This Field Is Required...!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public int Salary { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public string EMail { get; set; }
    }
}

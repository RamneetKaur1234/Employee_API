using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public string Name { get; set; }
    }
}

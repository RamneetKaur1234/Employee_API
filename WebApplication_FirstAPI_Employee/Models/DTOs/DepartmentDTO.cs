using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public string Name { get; set; }
    }
}

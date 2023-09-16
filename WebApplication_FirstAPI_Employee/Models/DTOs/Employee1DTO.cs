using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models.DTOs
{
    public class Employee1DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        [EmailAddress]
        public string EMail { get; set; }
    }
}

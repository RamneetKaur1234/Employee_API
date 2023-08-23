﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "This Field Is Required...!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field Is Required...!!")]
        public int Stipend { get; set; }
    }
}

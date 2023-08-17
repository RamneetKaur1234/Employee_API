﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_FirstAPI_Employee.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="This Field Is Mandatory...!!")]
        public string Username { get; set; }
        [Required (ErrorMessage = "This Field Is Mandatory...!!")]
        public string Password { get; set; }
        [Required (ErrorMessage = "This Field Is Mandatory...!!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

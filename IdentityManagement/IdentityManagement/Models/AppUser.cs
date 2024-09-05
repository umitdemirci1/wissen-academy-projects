﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityManagement.Models
{
    public class AppUser : IdentityUser
    {
        public Country Country { get; set; }
        public int Age {  get; set; }
        [Required]
        public string Salary {  get; set; }
    }
}

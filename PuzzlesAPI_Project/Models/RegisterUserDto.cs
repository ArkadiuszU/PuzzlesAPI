using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzlesAPI.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        public string RepeatPassword { get; set; }
        [Required]
        [MinLength(4)]
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Nation { get; set; }
    }
}

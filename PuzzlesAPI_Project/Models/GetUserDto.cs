using PuzzlesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzlesAPI.Models
{
    public class GetUserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}

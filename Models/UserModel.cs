using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Role { get; set; }
    }
}

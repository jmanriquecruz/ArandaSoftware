using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Core.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Names { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int IdRole { get; set; }
    }
}

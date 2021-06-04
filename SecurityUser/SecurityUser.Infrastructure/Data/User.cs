using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SecurityUser.Infrastructure.Data
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Names { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Rol { get; set; }
    }
}

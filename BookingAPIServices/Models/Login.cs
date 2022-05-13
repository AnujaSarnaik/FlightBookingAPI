using System;
using System.Collections.Generic;

#nullable disable

namespace BookingAPIServices.Models
{
    public partial class Login
    {
        public short Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

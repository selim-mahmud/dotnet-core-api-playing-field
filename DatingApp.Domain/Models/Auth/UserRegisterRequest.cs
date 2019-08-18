using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Domain.Models.Auth
{
    public class UserRegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

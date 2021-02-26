using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Authentification_JWT.Models
{
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
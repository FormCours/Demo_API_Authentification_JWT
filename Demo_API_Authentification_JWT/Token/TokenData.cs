using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Authentification_JWT.Token
{
    public class TokenData
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
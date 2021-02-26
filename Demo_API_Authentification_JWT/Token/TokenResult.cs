using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Authentification_JWT.Token
{
    public class TokenResult
    {
        public DateTime ExpireDate { get; set; }
        public string Token { get; set; }
    }
}
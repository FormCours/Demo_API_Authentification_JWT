using Demo_API_Authentification_JWT.Models;
using Demo_API_Authentification_JWT.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_API_Authentification_JWT.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {

        [AllowAnonymous]
        [HttpPost]
        [Route("GetToken")]
        public IHttpActionResult GetToken([FromBody] LoginUser login)
        {
            if (string.IsNullOrWhiteSpace(login.Username) || string.IsNullOrWhiteSpace(login.Password))
                return BadRequest();

            // TODO : Use real database !!!
            TokenData data = new TokenData();
            data.UserId = 42;
            data.Username = login.Username;
            data.Role = (login.Username.ToLower() == "balthazar") ? "Admin" : "User";

            // Génération du token
            TokenResult token = TokenManager.GenerateToken(data);

            // Envoie du token
            return Json(token);
        }
    }
}

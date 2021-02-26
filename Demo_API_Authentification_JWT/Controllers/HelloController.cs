using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Demo_API_Authentification_JWT.Controllers
{
    [RoutePrefix("api/hello")]
    public class HelloController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("notoken")]
        public IHttpActionResult NoToken()
        {
            return Json(new
            {
                msg= "Bienvenue inconnu :)"
            });
        }

        [Authorize]
        [HttpGet]
        [Route("user")]
        public IHttpActionResult ForUser()
        {
            ClaimsPrincipal claims = (ClaimsPrincipal)System.Web.HttpContext.Current.User;
            string username = claims.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return Json(new
            {
                msg = $"Bienvenue {username}"
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin")]
        public IHttpActionResult ForAdmin()
        {
            return Json(new
            {
                msg = "Bienvenue admin"
            });
        }
    }
}

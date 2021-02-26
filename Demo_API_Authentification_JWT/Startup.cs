using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Demo_API_Authentification_JWT.Token;
using Microsoft.IdentityModel.Tokens;
using System.Text;

[assembly: OwinStartup(typeof(Demo_API_Authentification_JWT.Startup))]

namespace Demo_API_Authentification_JWT
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Classe de démarrage Owin a ajouter (Ses dépendences s'installent automatiquement)

            // Pour utiliser les tokens, il est necessaire d'installer :
            //  - Microsoft.Owin.Security.Jwt
            //  - Microsoft.Owin.Host.SystemWeb
            //  - Microsoft.AspNet.WebApi.Owin

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions()
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = TokenManager.Issuer,
                        ValidateAudience = true,
                        ValidAudience = TokenManager.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.SecretKey))
                    }
                });
        }
    }
}

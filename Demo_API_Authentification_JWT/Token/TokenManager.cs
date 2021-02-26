using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Demo_API_Authentification_JWT.Token
{
    public static class TokenManager
    {
        /*
         *  - Dépendence a utiliser : 
         *  using System.Text;
         *  using System.Security.Claims;
         *  using Microsoft.IdentityModel.Tokens;
         *  using System.IdentityModel.Tokens.Jwt;
         */
        
        // TODO : Move this in web.config
        internal const string SecretKey = "V6YDvMX5SaojkXoNu+ZzBmmXgrpcw7LTqu0a9c1F/px5u3g488ZDzxNb67tiuoLha+U8ctbtRWmdBKWnjekfShpxGlTBoj1ANL44sRPX9c/JviukQMWbUZ2qwHWFLop5ozj7JXUXYn3TAiXHhcT5XU0zC7pvXAsAR3at2DkgNJQ=";
        internal const string Issuer = "http://site-demo-jwt.com";

        public static TokenResult GenerateToken(TokenData data)
        {
            // Ensemble des "claims" qu'on souhaite envoyer
            ClaimsIdentity claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, data.UserId.ToString()),
                new Claim(ClaimTypes.Name, data.Username),
                new Claim(ClaimTypes.Role, data.Role)
            });

            // Clef pour signer le token
            byte[] key = Encoding.UTF8.GetBytes(SecretKey);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Contenu du token
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = Issuer,
                Audience = Issuer,
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            // Génération du token
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.CreateJwtSecurityToken(tokenDescriptor);

            // Sérialisation du token en format texte
            string token = handler.WriteToken(jwtSecurityToken);

            return new TokenResult()
            {
                ExpireDate = (DateTime)tokenDescriptor.Expires,
                Token = token
            };
        }
    }
}
using DemoAuthAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoAuthAPI.Security
{

    public class JWTService
    {
        internal readonly string _issuer, _secret, _audience;

        private IConfiguration _config;
        public JWTService(IConfiguration config)
        {
            _config = config;
            _issuer = config.GetSection("tokenValidation").GetSection("issuer").Value;
            _audience = config.GetSection("tokenValidation").GetSection("audience").Value;
            _secret = config.GetSection("tokenValidation").GetSection("secret").Value;
        }

        public string GenerateJWT(UserClient user)
        {
            if (user.Email is null)
                throw new ArgumentNullException();

            //Création des crédentials
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Création de l'objet contenant les informations à stocker dans le token
            Claim[] myClaims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.NickName)
            };

            //Génération du token => Nuget : System.IdentityModel.Tokens.Jwt
            JwtSecurityToken token = new JwtSecurityToken(
                claims: myClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}


using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Api.Services
{
    public class JWTService : jwt
    {
        private readonly string _issuer; // Set the issuer based on your application
        private readonly string _audience; // Set the audience based on your application
        private readonly string Key = "sondeptraivippronumber1intheworldandthemosthandsomeman";
        //private readonly string _secretKey; // Set the secret key based on your application

        public JWTService(IConfiguration configuration)
        {
            // Retrieve configuration values for issuer, audience, and secret key
            _issuer = configuration.GetSection("Security.Bearer:Authority").Get<string>();
            _audience = configuration.GetSection("Security.Bearer:Audience").Get<string>();
            //_secretKey = configuration.GetSection("HRM Nh@ M@y Th3p!!!").Get<string>();
        }

        public string CreateToken(Domain.Entities.User user, IList<string> roles)
        {
            var tokenHanler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Key);
            var securityKey = new SymmetricSecurityKey(key);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("role", user.Roles.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credential
            };
            var token = tokenHanler.CreateToken(tokenDescription);
            return tokenHanler.WriteToken(token);
        }
    }
}
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
        private readonly string Key = "de455d3d7f83bf393eea5aef43f474f4aac57e3e8d75f9118e60d526453002dc";
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
                    var claims = new List<Claim>
         {
             //new Claim(JwtRegisteredClaimNames.Sub, userId),
             new Claim(JwtRegisteredClaimNames.Sub, user.Username),
             new Claim("Roles", user.Roles.ToString()),
             new Claim(JwtRegisteredClaimNames.Email, user.Email)
         };

                    if (roles != null)
                    {
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "test",
                        audience: "api",
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }
}
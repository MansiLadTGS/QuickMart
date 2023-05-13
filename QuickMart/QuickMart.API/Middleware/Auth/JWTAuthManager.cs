
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuickMart.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Middleware.Auth
{
    public class JWTAuthManager : IJWTAuthManager
    {
        private readonly IConfiguration _configuration;

        public JWTAuthManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJWT(Customer user)
        {
           // Response<string> response = new Response<string>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //claim is used to add identity to JWT token
            // var claims = new[] {
            //      new Claim( JwtRegisteredClaimNames.Sub, user.UserName),
            //      new Claim(JwtRegisteredClaimNames.Email, user.Email),
            //      new Claim("roles", user.Role),
            //      new Claim("Date", DateTime.Now.ToString()),
            //      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //  };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
            //   claims,    //null original value
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token); //return access token       
        }
    }
}

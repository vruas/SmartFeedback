﻿using Microsoft.IdentityModel.Tokens;
using SmartFeedback.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartFeedback.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("id", usuario.Id),
                new Claim("username", usuario.UserName),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString("yyyy-MM-dd")),
                new Claim("loginTimeStamp", DateTime.UtcNow.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

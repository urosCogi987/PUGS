﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Entities;

namespace TaxiApp.Infrastructure.Authentication
{
    public sealed class JwtProvider(IConfiguration configuration) : IJwtProvider
    {
        public string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenMinutes = double.Parse(configuration["Jwt:AccessTokenDurationInMinutes"]!);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };


            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(tokenMinutes), 
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateEmptyToken()
        {
            var randomNumber = new byte[64];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);

                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

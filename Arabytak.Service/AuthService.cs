using Arabytak.Core.Entities.Identity;
using Arabytak.Core.Service.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> manager)
        {
            var authClaims = new List<Claim>()
           {
               new Claim(ClaimTypes.Name,user.DisplayName),
               new Claim(ClaimTypes.Email,user.Email)
           };
            var userRoles=await manager.GetRolesAsync(user);
            // take the role and add to token when generate the token 
            foreach(var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role,role));
            }
            // we need install package becouse we need data (Authentication.jwtBearer)
            //this code take the authkey from appsetting and convert to bytes and generate to Security key use to validaed to token 
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"]));
            //RegisterClaims
            var Token = new JwtSecurityToken(
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssure"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"] ?? "0")),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authKey,SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}

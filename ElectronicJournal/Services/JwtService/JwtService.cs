using ElectronicJournal.Common;
using ElectronicJournal.Services.JwtService.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.JwtService
{
    public class JwtService: IJwtService
    {
        private readonly IOptions<AuthOptions> _options;
        public JwtService(IOptions<AuthOptions> options)
        {
            _options = options;
        }

        public string GenerateJWT(string userName, string id, string role)
        {
            var authParams = _options.Value;

            var securutyKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securutyKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, userName),
                new Claim(JwtRegisteredClaimNames.Sub, id),
                new Claim("role", role)
            };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

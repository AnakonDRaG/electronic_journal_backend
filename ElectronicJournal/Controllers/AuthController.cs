using ElectronicJournal.Common;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectronicJournal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IRepository<User> _users;
        private readonly IOptions<AuthOptions> _options;

        public AuthController(IRepository<User> users, IOptions<AuthOptions> options)
        {
            _users = users;
           _options = options;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var user = AuthenticateUser(request.Login, request.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);

                return Ok(new { acces_token = token });
            }

            return Unauthorized();
        }

        private User AuthenticateUser(string login, string password)
        {
            var user = _users.GetOneOrDefoult(u => u.Password == password && u.UserName == login);
            return user;
        }

        private string GenerateJWT(User user)
        {
            var authParams = _options.Value;

            var securutyKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securutyKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            claims.Add(new Claim("role", user.Role.ToString()));

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience,claims,
                expires: DateTime.Now.AddSeconds(authParams.LifeTime),
                signingCredentials : credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}

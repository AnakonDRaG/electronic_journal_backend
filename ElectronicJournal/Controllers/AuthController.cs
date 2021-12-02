using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using ElectronicJournal.Services.JwtService.Interfaces;
using ElectronicJournal.Services.StudentsService;
using ElectronicJournal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElectronicJournal.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AuthController : ControllerBase
    {
        private IRepository<User> _users;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private IList<string> _roles = new List<string>() { "Student", "Teacher" };

        public AuthController(IRepository<User> users, IJwtService jwtService, IMapper mapper, IStudentService studentService )
        {
            _users = users;
            _jwtService = jwtService;
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var user = _users.GetOneOrDefoult(u => u.Password == request.Password && u.UserName == request.Login);

            if (user != null)
            {
                var token = _jwtService.GenerateJWT(user.UserName, user.Id.ToString(), user.Role);

                return Ok(new { access_token = token });
            }

            return BadRequest(new { error = "Authorization is not valid"});
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] RegisterModel request)
        {
            var user = _users.GetOneOrDefoult(u => u.UserName == request.Login);

            if (user != null)
                return Unauthorized("User with same login exist yet");

            if(!_roles.Contains(request.Role))
                return Unauthorized("Invalid role");

            var human = _mapper.Map<Human>(request.Human);

            user = new User { Password = request.Password, UserName = request.Login, Role = request.Role, Human = human };

            _users.Add(user);
            _users.SaveChanges();

            var token = _jwtService.GenerateJWT(user.UserName, user.Id.ToString(), user.Role);

            return Ok(new { access_token = token});
        }

    }
}
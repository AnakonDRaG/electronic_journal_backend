using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using ElectronicJournal.Services.JwtService.Interfaces;
using ElectronicJournal.Services.StudentsService;
using ElectronicJournal.Services.TeacherService;
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
        private readonly ITeacherService _teacherService;
        private IList<string> _roles = new List<string>() {"student", "teacher"};

        public AuthController(IRepository<User> users, IJwtService jwtService, IMapper mapper,
            IStudentService studentService, ITeacherService teacherService)
        {
            _users = users;
            _jwtService = jwtService;
            _mapper = mapper;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var user = _users.GetOneOrDefault(user => user.UserName == request.Login);

            if (user != null)
            {
                if (user.Password != request.Password)
                    return BadRequest(new
                        {
                            errors = new
                            {
                                password = "Invalid password"
                            }
                        });

                var token = _jwtService.GenerateJWT(user.UserName, user.Id.ToString(), user.Role);

                return Ok(new {accessToken = token});
            }

            return BadRequest(new {message = "Authorization is not valid"});
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult CreateUser([FromBody] RegisterModel request)
        {
            var user = _users.GetOneOrDefault(u => u.UserName == request.Login);

            if (user != null)
                return BadRequest("This user already exists");

            if (!_roles.Contains(request.Role))
                return BadRequest(new {message = "Invalid role"});

            var human = _mapper.Map<Human>(request.Human);

            if (request.Role == "student")
                _studentService.AddStudent(human);
            else
                _teacherService.AddTeacher(human);

            user = new User
            {
                Password = request.Password,
                UserName = request.Login,
                Role = request.Role,
                Human = human
            };

            _users.Add(user);
            _users.SaveChanges();

            var token = _jwtService.GenerateJWT(user.UserName, user.Id.ToString(), user.Role);

            return Ok(new {access_token = token});
        }
    }
}
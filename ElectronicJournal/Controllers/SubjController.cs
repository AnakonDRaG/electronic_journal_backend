using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.Services.StudentsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectronicJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjController : ControllerBase
    {
        private IRepository<Subject> _subjects;
        private IRepository<User> _users;
        private readonly IStudentService _studentService;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public SubjController(IRepository<Subject> subjects, IRepository<User> users, IStudentService studentService)
        {
            _subjects = subjects;
            _users = users;
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Subject> GetAll()
        {
            return _subjects.GetAll();
        }

        [HttpGet]
        [Authorize]
        [Route("student/subjects")]
        public IEnumerable<Subject> GetSubjectForStudent()
        {
            var student = _studentService.GetStudentByUserId(UserId);
            return _subjects.GetSome(s=> s.SubjectsInJournal.Any(sj => sj.Journal.Class.Id == student.ClassId));
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [Route("teacher/subjects")]
        public IEnumerable<Subject> GetSubjectForTeacher()
        {
            return _subjects.GetAll();
        }

        [HttpGet]
        [Route("getOne")]
        public Subject GetOne([FromQuery] string titlr)
        {
            return _subjects.GetOneOrDefault(s => s.Name == titlr);
        }
    }
}

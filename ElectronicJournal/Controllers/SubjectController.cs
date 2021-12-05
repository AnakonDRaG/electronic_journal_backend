using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.Services.StudentsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ElectronicJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private IRepository<Subject> _subjects;
        private IRepository<User> _users;
        private readonly IStudentService _studentService;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public SubjectController(IRepository<Subject> subjects, IRepository<User> users, IStudentService studentService)
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
        [Route("student")]
        public IEnumerable<Subject> GetSubjectForStudent()
        {
            var student = _studentService.GetStudentByUserId(UserId);
            return _subjects.GetSome(s => s.SubjectsInJournal.Any(sj => sj.Journal.Class.Id == student.ClassId));
        }

        [HttpGet]
        [Authorize(Roles = "teacher")]
        [Route("teacher")]
        public IEnumerable<Subject> GetSubjectForTeacher()
        {
            return _subjects.GetAll();
        }

        [HttpGet]
        [Route("getOne")]
        public Subject GetOne([FromQuery] string subjectName)
        {
            return _subjects.GetOneOrDefault(s => s.Name == subjectName);
        }

        [HttpPost]
        [Route("add")]
        public Subject AddSubject([FromQuery] string subjectName)
        {
            var subject = new Subject()
            {
                Name = subjectName
            };

            _subjects.Add(subject);
            _subjects.SaveChanges();

            return _subjects.GetOneOrDefault(s => s.Name == subjectName);
        }
    }
}
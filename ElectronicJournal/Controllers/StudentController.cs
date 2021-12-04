using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
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
    public class StudentController : ControllerBase
    {
        private IFullRepository<Student> _students;
        private readonly IMapper _mapper;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public StudentController(IFullRepository<Student> students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;

        }

        [HttpPost]
        [Authorize]
        [Route("add/student/toClass")]
        public StudentsDTO AddToClass(int classId)
        {
            var student = _students.GetOneWithObjects(s => s.Human.UserId == UserId);

            student.ClassId = classId;
            _students.Update(student);
            _students.SaveChanges();

            return _mapper.Map<StudentsDTO>(student);
        }

    }
}

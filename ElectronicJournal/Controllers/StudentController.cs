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
        private IFullRepository<Class> _classes;
        private readonly IMapper _mapper;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public StudentController(IFullRepository<Student> students, IMapper mapper, IFullRepository<Class> classes)
        {
            _students = students;
            _mapper = mapper;
            _classes = classes;

        }

        [HttpPost]
        //[Authorize]
        [Route("add/student/toClass")]
        public StudentsDTO AddToClass(AddStudentToClassDto command)
        {
            var student = _students.GetOne(command.StudentId);
            if (student is null)
                throw new Exception("Student not found");

            var classForStudent = _classes.GetOne(command.ClassId);
            if (student is null)
                throw new Exception("Class not found");


            student.Class = classForStudent;
            _students.Update(student);
            _students.SaveChanges();

            return _mapper.Map<StudentsDTO>(student);
        }

        [HttpPost]
        //[Authorize]
        [Route("add/headman/toClass")]
        public ClassesDTO AddToHadmenClass(AddStudentToClassDto command)
        {
            var student = _students.GetOne(command.StudentId);
            if (student is null)
                throw new Exception("Student not found");

            var classForStudent = _classes.GetOne(command.ClassId);
            if (student is null)
                throw new Exception("Class not found");


            classForStudent.Headman = student;
            _classes.Update(classForStudent);
            _classes.SaveChanges();

            return _mapper.Map<ClassesDTO>(classForStudent);
        }


        [HttpGet]
        //[Authorize]
        [Route("get/all/students")]
        public IEnumerable<StudentsDTO> GetStudents()
        {
            var students = _students.GetAllWithObjects().ToList();
            return students.Select(t => _mapper.Map<StudentsDTO>(t));
        }

    }
}

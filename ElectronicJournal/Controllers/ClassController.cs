using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using ElectronicJournal.Services.StudentsService;
using ElectronicJournal.Services.TeacherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ElectronicJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IFullRepository<Class> _classes;
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public ClassController(IFullRepository<Class> classes, IMapper mapper, ITeacherService teacherService, IStudentService studentService)
        {
            _classes = classes;
            _mapper = mapper;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public IEnumerable<ClassesDTO> Home()
        {
            var human = _classes.GetAllWithObjects().ToList();

            return human.Select(h => {
                h.ClassroomTeacher = _teacherService.GetTeacherById(h.ClassroomTeacherId);
                h.Headman = _studentService.GetStudentById(h.HeadmanId);
                return _mapper.Map<ClassesDTO>(h);
            });
        }

        [HttpPost]
        [Authorize(Roles = "teacher")]
        [Route("create")]
        public ClassWithTeacherDto AddNewClass(CreateClassDto command)
        {
            var teacher = _teacherService.GetTeacherById(command.ClassroomTeacherId);
            if (teacher is null)
                throw new Exception("Teacher not found");

            var journal = new Journal() { DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddYears(1) };
            var newClass = new Class() { ClassroomTeacherId = teacher.Id, Name = command.Name, CurrentJournal = journal };

           _classes.Add(newClass);
            _classes.SaveChanges();

            return _mapper.Map<ClassWithTeacherDto>(newClass);
        }

        [HttpGet]
        [Route("{id}")]
        public ClassWithStudentDto GetClassById(int id)
        {
            var searchClass = _classes.GetOneWithObjects(id);
            if (searchClass is null)
                return null;

            searchClass.ClassroomTeacher = _teacherService.GetTeacherById(searchClass.ClassroomTeacherId);
            searchClass.Headman = _studentService.GetStudentById(searchClass.HeadmanId);

            searchClass.Students = searchClass.Students.Select(s => _studentService.GetStudentById(searchClass.Id)).ToList();

            return _mapper.Map<ClassWithStudentDto>(searchClass);
        }
    }
}
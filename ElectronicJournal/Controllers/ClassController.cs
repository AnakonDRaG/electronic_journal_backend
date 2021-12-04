using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
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
        private IRepository<Class> _classes;
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public ClassController(IRepository<Class> classes, IMapper mapper, ITeacherService teacherService)
        {
            _classes = classes;
            _mapper = mapper;
            _teacherService = teacherService;
        }

        [HttpGet]
        [Authorize]
        [Route("getAll")]
        public IEnumerable<ClassesDTO> Home()
        {
            var human = _classes.GetAll();
            return human.Select(h => _mapper.Map<ClassesDTO>(h));
        }

        [HttpPost]
        //[Authorize(Roles = "teacher")]
        [Route("create")]
        public ClassesDTO AddNewClass(CreateClassDto command)
        {
            var journal = new Journal() { DateStart = DateTime.UtcNow, DateEnd = DateTime.UtcNow.AddYears(1) };
            var newClass = new Class() { ClassroomTeacherId = command.ClassroomTeacherId, Name = command.Name, CurrentJournal = journal };

            _classes.Add(newClass);
            _classes.SaveChanges();

            return _mapper.Map<ClassesDTO>(newClass);
        }

        [HttpGet]
        [Route("{id}")]
        public ClassesDTO GetClassById(int id)
        {
            var searchClass = _classes.GetOne(id);
            if (searchClass is null)
                return null;

            return _mapper.Map<ClassesDTO>(searchClass);
        }
    }
}
using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using ElectronicJournal.Services.StudentsService;
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
    public class ScheduleController : ControllerBase
    {
        private IFullRepository<Student> _students;
        private IFullRepository<Lesson> _lessons;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public ScheduleController(IFullRepository<Student> students, IFullRepository<Lesson> lessonss, IMapper mapper, IStudentService studentService)
        {
            _students = students;
            _mapper = mapper;
            _studentService = studentService;
            _lessons = lessonss;
        }

        [HttpGet]
        [Authorize(Roles = "student")]
        [Route("student")]
        public IEnumerable<StudyDayDto> Home(int weekCount)
        {
            var student = _students.GetOneWithObjects(s => s.Human.UserId == UserId);

            var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday + weekCount * 7);
            var friday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday + weekCount * 7);

            var lessonsScores = student.LessonsScores.Where(l => l.Lesson.Date >= monday && l.Lesson.Date <= friday).Select(ls => ls.LessonId).ToArray();
            var lessons = _lessons.GetAllWithObjects(l => lessonsScores.Contains(l.Id));

            var lessonDto = lessons.Select(l => _mapper.Map<LessonsDTO>(l));
            var studyDays = lessonDto.GroupBy(p => p.Date)
                        .Select(g => new StudyDayDto
                        {
                            Date = g.Key,
                            Count = g.Count(),
                            Lessons = g.Select(p => p).ToList()
                        });

            return studyDays;
        }
    }
}
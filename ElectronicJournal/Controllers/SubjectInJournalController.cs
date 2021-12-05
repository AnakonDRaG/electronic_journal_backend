using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using ElectronicJournal.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectInJournalController : ControllerBase
    {
        private IRepository<Subject> _subjects;
        private IRepository<Journal> _journals;
        private IFullRepository<SubjectInJournal> _subjectsInJournals;
        private ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public SubjectInJournalController(IMapper mapper, IRepository<Subject> subjects, IRepository<Journal> journals, IFullRepository<SubjectInJournal> subjectsInJournals, ITeacherService teacherService)
        {
            _subjects = subjects;
            _journals = journals;
            _teacherService = teacherService;
            _subjectsInJournals = subjectsInJournals;
            _mapper = mapper;
        }

        [HttpGet]
        public SubjectInJournal GetOne(int id)
        {
            var subjects = _subjectsInJournals.GetOneWithObjects(id);

            return subjects;//_mapper.Map<SubjectsInJournalsDTO>(subjects);
        }

        [HttpPost]
        //[Authorize]
        [Route("add/subject-in-journal")]
        public ActionResult AddSubjectToJournal(SubjectInJournalDto command)
        {
            var subject = _subjects.GetOne(command.SubjectId);
            if (subject is null)
                throw new Exception("Subject not found");

            var journal = _journals.GetOne(command.JournalId);
            if (journal is null)
                throw new Exception("Journa not found");

            var teacher = _teacherService.GetTeacherById(command.TeacherId);
            if (teacher is null)
                throw new Exception("Teacher not found");

            var subjectInJournal = new SubjectInJournal()
            {
                TeacherId = teacher.Id,
                SubjectId = subject.Id,
                JournalId = journal.Id
            };

            _subjectsInJournals.Add(subjectInJournal);
            _subjectsInJournals.SaveChanges();

            return Ok();
        }

        [HttpGet]
        //[Authorize]
        [Route("get/all")]
        public IEnumerable<SubjectsInJournalsDTO> GetSubjectToJournal()
        {
            var subjects = _subjectsInJournals.GetAllWithObjects();

            return subjects.Select(s => 
            {
                s.Teacher = _teacherService.GetTeacherById(s.TeacherId);
                return  _mapper.Map<SubjectsInJournalsDTO>(s);
             });
        }

        [HttpGet]
        //[Authorize]
        [Route("get/subjects")]
        public IEnumerable<SubjectsInJournalsDTO> GetSubjectToJournal(int JournalId)
        {
            var subjects = _subjectsInJournals.GetAllWithObjects( s=> s.JournalId == JournalId);

            return subjects.Select(s =>
            {
                s.Teacher = _teacherService.GetTeacherById(s.TeacherId);
                return _mapper.Map<SubjectsInJournalsDTO>(s);
            });
        }


    }
}

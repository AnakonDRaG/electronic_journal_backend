using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
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
    public class TeacherController: ControllerBase
    {
        private IRepository<Teacher> _teachers;
        private readonly IMapper _mapper;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public TeacherController(IRepository<Teacher> teachers, IMapper mapper)
        {
            _teachers = teachers;
            _mapper = mapper;

        }

        [HttpGet]
        //[Authorize]
        [Route("get/teachers")]
        public IEnumerable<TeachersDTO> GetAll()
        {
            var teachers = _teachers.GetAll().ToList();
            return teachers.Select(t => _mapper.Map<TeachersDTO>(t));
        }

    }
}

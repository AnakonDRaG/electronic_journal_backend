using AutoMapper;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO.ModelsDTO;
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
    public class HumanController : ControllerBase
    {
        private IFullRepository<Human> _humans;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public HumanController(IFullRepository<Human> humans, IMapper mapper, IStudentService studentService)
        {
            _humans = humans;
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize]
        [Route("home")]
        public HumansDTO Home()
        {
            var human = _humans.GetOneWithObjects(h => h.User.Id == UserId);
            return _mapper.Map<HumansDTO>(human);
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<HumansDTO> GetAllHumans()
        {
            var humans = _humans.GetAllWithObjects();
            return humans.Select(h => _mapper.Map<HumansDTO>(h));
        }
    }
}
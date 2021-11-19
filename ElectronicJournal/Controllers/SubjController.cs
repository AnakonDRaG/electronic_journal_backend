using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
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
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public SubjController(IRepository<Subject> subjects, IRepository<User> users)
        {
            _subjects = subjects;
            _users = users;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Subject> GetAll()
        {
            return _subjects.GetAll();
        }

        [HttpGet]
        [Route("id")]
        public int GetId()
        {
            return UserId;
        }

        [HttpGet]
        [Route("get")]
        public Subject GetOne([FromQuery] string titlr)
        {
            return _subjects.GetOneOrDefoult(s => s.Name == titlr);
        }

        [HttpGet]
        [Route("get/user")]
        public User GetOneUser([FromQuery] string titlr)
        {
            return _users.GetOneOrDefoult(s => s.Password == titlr);
        }


    }
}

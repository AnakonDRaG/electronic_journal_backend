using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.TeacherService
{
    public class TeacherService : BaseHumanService, ITeacherService
    {
        private readonly IFullRepository<Teacher> _repository;
        public TeacherService(IFullRepository<Teacher> repository, IRepository<Human> humanRepository): base(humanRepository)
        {
            _repository = repository;
        }

        public Teacher AddTeacher(Human human)
        {
            var teacher = new Teacher() { Human = human };
            _repository.Add(teacher);
            return teacher;
        }

        public Teacher AddTeacher(int humanId)
        {
            //var human = GetHumanById(humanId);
            var teacher = new Teacher() { HumanId = humanId };
            //_repository.Add(teacher);
            return teacher;
        }

        public Teacher GetTeacherByUserId(int id)
        {
            return _repository.GetOneOrDefault(s => s.Human.UserId == id);
        }

        public Teacher GetTeacherById(int id)
        {
            return _repository.GetOneWithObjects(id);
        }
    }
}

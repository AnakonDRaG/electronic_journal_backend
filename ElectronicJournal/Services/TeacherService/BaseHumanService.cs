using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.TeacherService
{
    public class BaseHumanService
    {
        private readonly IRepository<Human> _humanRepository;
        public BaseHumanService(IRepository<Human> repository)
        {
            _humanRepository = repository;
        }

        public Human GetHumanById(int id)
        {
            return _humanRepository.GetOne(id);
        }
    }
}

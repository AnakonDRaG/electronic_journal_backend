using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Data.Repositorie.Interfaces;
using System.Linq.Expressions;

namespace ElectronicJournal.Data.Repositorie
{
    public class HumanRepository : BaseRepository<Human>, IFullRepository<Human>
    {
        public HumanRepository(DbContext context) : base(context)
        {}

        public IEnumerable<Human> GetAllWithObjects()
        {
            var humans = _context.Set<Human>().AsNoTracking()
                 .Include(a => a.User)
                 .ToList();

            return humans;
        }

        public IEnumerable<Human> GetAllWithObjects(Expression<Func<Human, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Human GetOneWithObjects(int id)
        {
            var human = _context.Set<Human>().AsNoTracking().Where(a => a.Id == id)
                .Include(a => a.User)
                .FirstOrDefault();

            return human;
        }

        public Human GetOneWithObjects(Expression<Func<Human, bool>> where)
        {
            var human = _context.Set<Human>().AsNoTracking().Where(where)
                .Include(a => a.User)
                .FirstOrDefault();

            return human;
        }
    }
}
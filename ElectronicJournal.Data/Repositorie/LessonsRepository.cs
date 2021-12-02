using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Data.Repositorie
{
    public class LessonsRepository : BaseRepository<Lesson>, IFullRepository<Lesson>
    {
        public LessonsRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Lesson> GetAllWithObjects()
        {
            return null;
        }

        public IEnumerable<Lesson> GetAllWithObjects(Expression<Func<Lesson, bool>> where)
        {
            var human = _context.Set<Lesson>().AsNoTracking().Where(where)
               .Include(a => a.SubjectInJournal)
               .ToList();

            return human;
        }

        public Lesson GetOneWithObjects(int id)
        {
            return null;
        }

        public Lesson GetOneWithObjects(Expression<Func<Lesson, bool>> where)
        {
            var human = _context.Set<Lesson>().AsNoTracking().Where(where)
                .Include(a => a.SubjectInJournal)
                .FirstOrDefault();

            return human;
        }
    }
}

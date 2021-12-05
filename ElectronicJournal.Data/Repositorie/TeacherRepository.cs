using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Data.Repositorie
{
    public class TeacherRepository : BaseRepository<Teacher>, IFullRepository<Teacher>
    {
        public TeacherRepository(DbContext context) : base(context)
        {}

        public IEnumerable<Teacher> GetAllWithObjects()
        {
            var teacher = _context.Set<Teacher>().AsNoTracking()
               .Include(a => a.Human)
               .Include(a => a.CurrentClass)
               .ToList();

            return teacher;
        }

            public Teacher GetOneWithObjects(int id)
        {
            var teacher = _context.Set<Teacher>().AsNoTracking().Where(t => t.Id == id)
               .Include(a => a.Human)
               .Include(a => a.CurrentClass)
               .FirstOrDefault();

            return teacher;
        }

        public Teacher GetOneWithObjects(Expression<Func<Teacher, bool>> @where)
        {
            var teacher = _context.Set<Teacher>().AsNoTracking().Where(where)
                .Include(a => a.Human)
                .Include(a => a.CurrentClass)
                .FirstOrDefault();

            return teacher;
        }

        public IEnumerable<Teacher> GetAllWithObjects(Expression<Func<Teacher, bool>> @where)
        {
            throw new NotImplementedException();
        }
    }
}
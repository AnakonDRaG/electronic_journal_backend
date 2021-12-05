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
    public class ClassRepository : BaseRepository<Class>, IFullRepository<Class>
    {
        public ClassRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Class> GetAllWithObjects()
        {
            var classes = _context.Set<Class>().AsNoTracking()
                 .Include(a => a.ClassroomTeacher)
                 .Include(a => a.Headman)
                 .Include(a => a.Journals)
                 .Include(a => a.Students)
                 .ToList();

            return classes;
        }

        public IEnumerable<Class> GetAllWithObjects(Expression<Func<Class, bool>> where)
        {
            var classes = _context.Set<Class>().AsNoTracking()
                 .Include(a => a.ClassroomTeacher)
                 .Include(a => a.Headman)
                 .Include(a => a.Journals)
                 .Include(a => a.Students)
                 .Where(where)
                 .ToList();

            return classes;
        }

        public Class GetOneWithObjects(int id)
        {
            var classes = _context.Set<Class>().AsNoTracking()
                  .Include(a => a.ClassroomTeacher)
                  .Include(a => a.Headman)
                  .Include(a => a.Journals)
                  .Include(a => a.Students)
                  .Where(c => c.Id == id)
                  .FirstOrDefault();

            return classes;
        }

        public Class GetOneWithObjects(Expression<Func<Class, bool>> where)
        {
            var classes = _context.Set<Class>().AsNoTracking()
                 .Include(a => a.ClassroomTeacher)
                 .Include(a => a.Headman)
                 .Include(a => a.Journals)
                 .Include(a => a.Students)
                 .Where(where)
                 .FirstOrDefault();

            return classes;
        }
    }
}

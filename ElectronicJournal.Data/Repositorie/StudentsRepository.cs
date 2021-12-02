using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ElectronicJournal.Data.Repositorie
{
    public class StudentsRepository : BaseRepository<Student>, IFullRepository<Student>
    {
        public StudentsRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Student> GetAllWithObjects()
        {
            /* var articles = _context.Set<Human>().AsNoTracking()
                  .Include(a => a.Tags)
                  .Include(a => a.Likes)
                  .Include(a => a.Profile);*/

            return null;
        }

        public IEnumerable<Student> GetAllWithObjects(Expression<Func<Student, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Student GetOneWithObjects(int id)
        {
            /*var article = _context.Set<Human>().AsNoTracking().Where(a => a.Id == id)
                .Include(a => a.Tags)
                .Include(a => a.Likes)
                .Include(a => a.Profile)
                .FirstOrDefault();*/

            return null;
        }

        public Student GetOneWithObjects(Expression<Func<Student, bool>> where)
        {
            var student = _context.Set<Student>().AsNoTracking().Where(where)
                .Include(a => a.Human)
                .Include(a => a.LessonsScores)
                .FirstOrDefault();

            return student;
        }
    }
}
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
            var student = _context.Set<Student>().AsNoTracking()
             .Include(a => a.Human)
             .Include(a => a.LessonsScores)
             .ToList();

            return student;
        }

        public IEnumerable<Student> GetAllWithObjects(Expression<Func<Student, bool>> where)
        {
            var student = _context.Set<Student>().AsNoTracking().Where(where)
              .Include(a => a.Human)
              .Include(a => a.LessonsScores)
              .ToList();

            return student;
        }

        public Student GetOneWithObjects(int id)
        {
            var student = _context.Set<Student>().AsNoTracking().Where(s => s.Id == id)
               .Include(a => a.Human)
               .Include(a => a.LessonsScores)
               .FirstOrDefault();

            return student;
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
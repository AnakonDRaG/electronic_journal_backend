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
    public class SubjectInJournalRepository : BaseRepository<SubjectInJournal>, IFullRepository<SubjectInJournal>
    {
        public SubjectInJournalRepository(DbContext context) : base(context)
        { }

        public IEnumerable<SubjectInJournal> GetAllWithObjects()
        {
            var subjectInJournals = _context.Set<SubjectInJournal>().AsNoTracking()
                .Include(a => a.Journal)
                .Include(a => a.Teacher)
                .Include(a => a.Subject)
                .ToList();

            return subjectInJournals;
        }

        public IEnumerable<SubjectInJournal> GetAllWithObjects(Expression<Func<SubjectInJournal, bool>> where)
        {
            var subjectInJournals = _context.Set<SubjectInJournal>().AsNoTracking().Where(where)
                 .Include(a => a.Journal)
                .Include(a => a.Teacher)
                .Include(a => a.Subject)
                .ToList();

            return subjectInJournals;
        }

        public SubjectInJournal GetOneWithObjects(int id)
        {
            var subjectInJournals = _context.Set<SubjectInJournal>().AsNoTracking().Where(a => a.Id == id)
                .Include(a => a.Journal)
                .Include(a => a.Teacher)
                .Include(a => a.Subject)
                .FirstOrDefault();

            return subjectInJournals;
        }

        public SubjectInJournal GetOneWithObjects(Expression<Func<SubjectInJournal, bool>> where)
        {
            var subjectInJournals = _context.Set<SubjectInJournal>().AsNoTracking().Where(where)
              .Include(a => a.Journal)
              .Include(a => a.Teacher)
              .Include(a => a.Subject)
              .FirstOrDefault();

            return subjectInJournals;
        }
    }
}

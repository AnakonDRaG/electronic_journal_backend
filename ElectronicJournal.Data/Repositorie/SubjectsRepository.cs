using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Data.Repositorie
{
    public class SubjectsRepository : BaseRepository<Subject>, IFullRepository<Subject>
    {
        public SubjectsRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Subject> GetAllWithObjects()
        {
            var subjects = _context.Set<Subject>().AsNoTracking()
                .ToList();

            return subjects;
        }

        public Subject GetOneWithObjects(int id)
        {
            throw new NotImplementedException();
        }

        public Subject GetOneWithObjects(Expression<Func<Subject, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetAllWithObjects(Expression<Func<Subject, bool>> @where)
        {
            throw new NotImplementedException();
        }
    }
}
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
    public class LessonScoreRepository : BaseRepository<LessonScore>, IFullRepository<LessonScore>
    {
        public LessonScoreRepository(DbContext context) : base(context)
        { }

        public IEnumerable<LessonScore> GetAllWithObjects()
        {
            return null;
        }

        public IEnumerable<LessonScore> GetAllWithObjects(Expression<Func<LessonScore, bool>> where)
        {
            throw new NotImplementedException();
        }

        public LessonScore GetOneWithObjects(int id)
        {
            return null;
        }

        public LessonScore GetOneWithObjects(Expression<Func<LessonScore, bool>> where)
        {
            var human = _context.Set<LessonScore>().AsNoTracking().Where(where)
                .Include(a => a.Lesson)
                .FirstOrDefault();

            return human;
        }
    }
}

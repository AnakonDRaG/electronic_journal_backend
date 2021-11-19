using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Data.Repositorie.Interfaces;

namespace ElectronicJournal.Data.Repositorie
{
    public class HumanRepository : BaseRepository<Human>, IFullRepository<Human>
    {
        public HumanRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Human> GetAllWithObjects()
        {
           /* var articles = _context.Set<Human>().AsNoTracking()
                 .Include(a => a.Tags)
                 .Include(a => a.Likes)
                 .Include(a => a.Profile);*/

            return null;
        }

        public Human GetOneWithObjects(int id)
        {
            /*var article = _context.Set<Human>().AsNoTracking().Where(a => a.Id == id)
                .Include(a => a.Tags)
                .Include(a => a.Likes)
                .Include(a => a.Profile)
                .FirstOrDefault();*/

            return null;
        }
    }
}
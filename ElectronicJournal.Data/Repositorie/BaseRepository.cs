using Microsoft.EntityFrameworkCore;
using ElectronicJournal.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Data.Repositorie.Interfaces;

namespace ElectronicJournal.Data.Repositorie
{
    public class BaseRepository<E> : IRepository<E>
        where E : BaseModel
    {
        private protected DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<E> GetAll()
        {
            return _context.Set<E>();
        }

        public IEnumerable<E> GetAllWithoutTracking()
        {
            return _context.Set<E>().AsNoTracking();
        }

        public E GetOne(int id)
        {
            return _context.Find<E>(id);
        }

        public void Add(E entity)
        {
            _context.Add(entity);
        }

        public void Add(IList<E> entities)
        {
            _context.AddRange(entities);
        }

        public void Update(E entity)
        {
            _context.Update(entity);
        }

        public void Update(IList<E> entities)
        {
            _context.UpdateRange(entities);
        }

        public void Delete(int id)
        {
            var entity = GetOne(id);
            if (entity != null)
                _context.Remove(entity);
        }

        public IEnumerable<E> GetSome(Func<E, bool> where)
        {
            return _context.Set<E>().Where(where);
        }

        public E GetOneOrDefault(Func<E, bool> where)
        {
            var entity = _context.Set<E>().Where(where).FirstOrDefault();
            return entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

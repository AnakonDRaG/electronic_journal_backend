using ElectronicJournal.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Data.Repositorie.Interfaces
{
    public interface IRepository<E> where E : BaseModel
    {
        IEnumerable<E> GetAll();

        IEnumerable<E> GetAllWithoutTracking();

        E GetOne(int id);

        void Add(E entity);

        void Add(IList<E> entities);

        void Update(E entity);

        void Update(IList<E> entities);

        void Delete(int id);

        IEnumerable<E> GetSome(Func<E, bool> where);

        E GetOneOrDefault(Func<E, bool> where);

        void SaveChanges();

    }

}

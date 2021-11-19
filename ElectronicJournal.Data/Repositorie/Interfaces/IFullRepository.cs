using ElectronicJournal.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Data.Repositorie.Interfaces
{
    public interface IFullRepository<E> : IRepository<E>
        where E : BaseModel
    {
        IEnumerable<E> GetAllWithObjects();

        E GetOneWithObjects(int id);
    }

}

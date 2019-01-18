using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabify.Data.Contracts
{
    public interface IEfDbSetWrapper<T>
    {
        IQueryable<T> All { get; }

        T GetById(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

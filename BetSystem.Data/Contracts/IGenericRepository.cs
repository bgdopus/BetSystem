using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        T Get(int id);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}

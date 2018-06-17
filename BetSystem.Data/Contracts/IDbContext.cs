using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Data.Contracts
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry Entry<T>(T entity) where T : class;

        int SaveChanges();

        void Dispose();
    }
}

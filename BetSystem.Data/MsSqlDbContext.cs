using System;
using System.Linq;
using System.Data.Entity;
using BetSystem.Data.Models;
using BetSystem.Data.Contracts;
using System.Data.Entity.Infrastructure;

namespace BetSystem.Data
{
    public class MsSqlDbContext : DbContext, IDbContext
    {
        private static readonly string DbConnectionName = "LocalConnection";

        public MsSqlDbContext(): base(DbConnectionName)
        {
        }

        public DbSet<Event> Events { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }

        DbEntityEntry IDbContext.Entry<T>(T entity)
        {
            return this.Entry<T>(entity);
        }
    }
}

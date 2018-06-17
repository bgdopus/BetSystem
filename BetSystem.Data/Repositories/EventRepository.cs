using BetSystem.Data.Contracts;
using BetSystem.Data.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Data.Repositories
{
    public class EventRepository : IGenericRepository<Event>
    {
        private readonly IDbContext context;

        public EventRepository(IDbContext context)
        {
            Guard.WhenArgument(context, "IDbContext").IsNull().Throw();

            this.context = context;
        }
        
        public IQueryable<Event> All
        {
            get
            {
                return this.context.Set<Event>().Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<Event> AllAndDeleted => throw new NotImplementedException();

        public void Add(Event entity)
        {
            Guard.WhenArgument(entity, "EntityToAdd").IsNull().Throw();

            this.context.Set<Event>().Add(entity);
            this.context.SaveChanges();
        }
        
        public Event Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Event entity)
        {
            throw new NotImplementedException();
        }


        public void Update(Event entity)
        {
            Guard.WhenArgument(entity, "EntityToUpdate").IsNull().Throw();

            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.context.Set<Event>().Attach(entity);
            }

            entry.State = EntityState.Modified;

            this.context.SaveChanges();
            
        }
    }
}

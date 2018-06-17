using BetSystem.Data.Contracts;
using BetSystem.Services.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Services.Abstract
{
    public abstract class DataService<T> : IDataService<T>
        where T : class
    {
        public DataService(IGenericRepository<T> dataRepository)
        {
            Guard.WhenArgument(dataRepository, "DataRepository").IsNull().Throw();

            this.Data = dataRepository;
        }

        public IGenericRepository<T> Data { get; private set; }

        public IEnumerable<T> GetAll()
        {
            return this.Data.All.ToList();
        }
    }
}

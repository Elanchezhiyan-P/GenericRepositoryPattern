using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectorLibrary.Persistences.Repository
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext Context;
        protected UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public int Complete()
        {
            return Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

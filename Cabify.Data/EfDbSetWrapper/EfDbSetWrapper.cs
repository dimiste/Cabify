using Bytes2you.Validation;
using Cabify.Data.Contracts;

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Cabify.Data.EfDbSetWrapper
{
    public class EfDbSetWrapper<T> : IEfDbSetWrapper<T> where T : class
    {
        private readonly IEfDbContext efDbContext;
        private readonly IDbSet<T> dbSet;

        public EfDbSetWrapper(IEfDbContext efDbContext)
        {
            Guard.WhenArgument(efDbContext, "efDbContext").IsNull().Throw();

            this.efDbContext = efDbContext;

            this.dbSet = efDbContext.Set<T>();
        }

        public IQueryable<T> All => this.dbSet;

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public void Add(T entity)
        {

            DbEntityEntry entry = this.efDbContext.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.efDbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.efDbContext.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }
    }
}

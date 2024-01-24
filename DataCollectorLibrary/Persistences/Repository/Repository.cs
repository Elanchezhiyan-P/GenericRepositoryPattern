using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectorLibrary.Persistences.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entities;

        protected Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            return _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public TEntity Attach(TEntity entity)
        {
            return _entities.Attach(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public TEntity Get(string id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause)
        {
            return _entities.Where(whereClause).ToList();
        }

        public IEnumerable<TEntity> GetNTopRecordsByDesc(Expression<Func<TEntity, long>> predicate, int quantity)
        {
            return _entities.OrderByDescending(predicate).Take(quantity);
        }

        public IEnumerable<TEntity> GetNTopRecordsByAsc(Expression<Func<TEntity, long>> predicate, int quantity)
        {
            return _entities.OrderBy(predicate).Take(quantity);
        }

        public IEnumerable<TEntity> GetNTopRecordsByDesc(Expression<Func<TEntity, DateTime>> predicate, int quantity)
        {
            return _entities.OrderByDescending(predicate).Take(quantity);
        }

        public IEnumerable<TEntity> GetNTopRecordsByDescWithWhere(Expression<Func<TEntity, long>> predicate, int quantity, Expression<Func<TEntity, bool>> whereClause)
        {
            return _entities.Where(whereClause).OrderByDescending(predicate).Take(quantity);
        }

        public IEnumerable<TEntity> GetNTopRecordsByAscWithWhere(Expression<Func<TEntity, long>> predicate, int quantity, Expression<Func<TEntity, bool>> whereClause)
        {
            return _entities.Where(whereClause).OrderBy(predicate).Take(quantity);
        }

        public IEnumerable<TEntity> GetNTopRecordsByAsc(Expression<Func<TEntity, DateTime>> predicate, int quantity)
        {
            return _entities.OrderBy(predicate).Take(quantity);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectorLibrary.Persistences.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
        TEntity Attach(TEntity entity);
        TEntity Get(int id);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetNTopRecordsByDesc(Expression<Func<TEntity, long>> predicate, int quantity);
        IEnumerable<TEntity> GetNTopRecordsByAsc(Expression<Func<TEntity, long>> predicate, int quantity);
        IEnumerable<TEntity> GetNTopRecordsByDesc(Expression<Func<TEntity, DateTime>> predicate, int quantity);
        IEnumerable<TEntity> GetNTopRecordsByAsc(Expression<Func<TEntity, DateTime>> predicate, int quantity);
        IEnumerable<TEntity> GetNTopRecordsByDescWithWhere(Expression<Func<TEntity, long>> predicate, int quantity, Expression<Func<TEntity, bool>> whereClause);
        IEnumerable<TEntity> GetNTopRecordsByAscWithWhere(Expression<Func<TEntity, long>> predicate, int quantity, Expression<Func<TEntity, bool>> whereClause);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}

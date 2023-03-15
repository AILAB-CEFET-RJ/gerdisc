using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace gerdisc.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll();
        int Count();
        TEntity? GetSingle(int id);
        TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        void Commit();
    }
}
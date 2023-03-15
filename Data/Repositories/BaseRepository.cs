using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using gerdisc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace gerdisc.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private ContexRepository _context;
        private DbSet<TEntity> _dbSet;

        protected BaseRepository(ContexRepository dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }
        public virtual IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public TEntity? GetSingle(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<TEntity>(entity);
            var en = _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = _dbSet.Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<TEntity>(entity).State = EntityState.Deleted;
            }
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}
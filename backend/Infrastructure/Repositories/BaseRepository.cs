using System.Linq.Expressions;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace gerdisc.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ContexRepository _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ContexRepository context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _dbSet.IncludeMultiple(includeProperties).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _dbSet.IncludeMultiple(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = includeProperty(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _dbSet.IncludeMultiple(includeProperties).Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Include(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().CountAsync(predicate).ConfigureAwait(false);
        }
    }
}

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
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity?> GetByIdAsync(
            Guid id,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<TEntity?> GetByIdAsync(
            Guid id,
            Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Where(predicate)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity?> GetByIdAsync(
            Guid id,
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .Where(predicate)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(
            IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.Where(e => !e.IsDeleted);

            foreach (var includeProperty in includeProperties)
            {
                query = includeProperty(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPagedAsync(
            Expression<Func<TEntity, bool>> predicate,
            int pageNumber,
            int pageSize,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .Where(predicate).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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

        public virtual async Task DeactiveAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public virtual async Task DeactiveByIdAsync(Guid id)
        {
            TEntity? entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete == null)
                throw new ArgumentNullException(nameof(entityToDelete));

            entityToDelete.IsDeleted = true;
            await UpdateAsync(entityToDelete);
        }

        public virtual async Task DeactiveRangeAsync(
            IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeactiveRangeAsync(
            Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = await _dbSet
                .Where(predicate)
                .ToListAsync();

            foreach (var entity in entitiesToDelete)
            {
                entity.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> CountAsync(
            Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .AsNoTracking()
                .CountAsync(e => !e.IsDeleted && predicate.Compile()(e))
                .ConfigureAwait(false);
        }
    }
}

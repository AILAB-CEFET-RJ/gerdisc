using System.Linq.Expressions;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Infrastructure.Providers;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Orientation
{
    /// <inheritdoc />
    public class OrientationRepository : BaseRepository<OrientationEntity>, IOrientationRepository
    {
        private readonly IUserContext _userContext;
        public OrientationRepository(ContexRepository dbContext, IUserContext userContext) : base(dbContext)
        {
            _userContext = userContext;
        }

        /// <inheritdoc />
        public override async Task<OrientationEntity?> GetByIdAsync(
            Guid id,
            params Expression<Func<OrientationEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .FilterByUserRole(_userContext)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<OrientationEntity>> GetByRoleAsync(
            params Expression<Func<OrientationEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .FilterByUserRole(_userContext)
                .ToListAsync();
        }
    }
}
using System.Linq.Expressions;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Dissertation
{
    public class DissertationRepository : BaseRepository<DissertationEntity>, IDissertationRepository
    {
        private readonly IUserContext _userContext;
        public DissertationRepository(ContexRepository dbContext, IUserContext userContext) : base(dbContext)
        {
            _userContext = userContext;
        }

        public override async Task<DissertationEntity?> GetByIdAsync(
            Guid id,
            params Expression<Func<DissertationEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .FilterByUserRole(_userContext)
                .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<DissertationEntity>> GetByRoleAsync(
            params Expression<Func<DissertationEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .FilterByUserRole(_userContext)
                .ToListAsync();
        }
    }
}
using System.Linq.Expressions;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Infrastructure.Providers;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Extension
{
    /// <inheritdoc />
    public class ExtensionRepository : BaseRepository<ExtensionEntity>, IExtensionRepository
    {
        private readonly IUserContext _userContext;
        public ExtensionRepository(ContexRepository dbContext, IUserContext userContext) : base(dbContext)
        {
            _userContext = userContext;
        }

        /// <inheritdoc />
        public override async Task<ExtensionEntity?> GetByIdAsync(
            Guid id,
            params Expression<Func<ExtensionEntity, object>>[] includeProperties)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .IncludeMultiple(includeProperties)
                .FilterByUserRole(_userContext)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
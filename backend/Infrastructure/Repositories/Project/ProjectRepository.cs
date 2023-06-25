using gerdisc.Infrastructure.Extensions;
using gerdisc.Infrastructure.Providers;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Project
{
    /// <inheritdoc />
    public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
    {
        private readonly IUserContext _userContext;
        public ProjectRepository(ContexRepository dbContext, IUserContext userContext) : base(dbContext)
        {
            _userContext = userContext;
        }

        /// <inheritdoc />
        public override async Task<ProjectEntity?> GetByIdAsync(
            Guid id)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .Include(x => x.Orientations)
                .Include(x => x.Students)
                .FilterByUserRole(_userContext)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc />
        public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .Include(x => x.Orientations)
                .Include(x => x.Students)
                .ThenInclude(x => x.User)
                .FilterByUserRole(_userContext)
                .ToListAsync();
        }
    }
}
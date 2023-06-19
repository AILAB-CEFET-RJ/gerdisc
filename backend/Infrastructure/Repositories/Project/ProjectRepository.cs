using gerdisc.Infrastructure.Extensions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Project
{
    public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
    {
        private readonly IUserContext _userContext;
        public ProjectRepository(ContexRepository dbContext, IUserContext userContext) : base(dbContext)
        {
            _userContext = userContext;
        }

        public override async Task<ProjectEntity?> GetByIdAsync(
            Guid id)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .Include(x => x.Dissertations)
                .Include(x => x.Students)
                .FilterByUserRole(_userContext)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .Include(x => x.Dissertations)
                .Include(x => x.Students)
                .FilterByUserRole(_userContext)
                .ToListAsync();
        }
    }
}
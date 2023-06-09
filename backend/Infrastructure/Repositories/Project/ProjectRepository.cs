using System.Linq.Expressions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace gerdisc.Infrastructure.Repositories.Project
{
    public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(ContexRepository dbContext) : base(dbContext)
        {
        }

        public override async Task<ProjectEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .Include(x => x.Dissertations)
                .ThenInclude(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .ThenInclude(x => x.User)
                .Include(x => x.Dissertations)
                .ThenInclude(x => x.Student)
                .ToListAsync();
        }
    }
}
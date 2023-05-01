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

        public override async Task<ProjectEntity> GetByIdAsync(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _dbSet
                .Include(x => x.ProfessorProjects)
                .ThenInclude(x => x.Professor)
                .Include(x => x.Dissertations)
                .ThenInclude(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
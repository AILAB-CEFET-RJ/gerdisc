using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Project
{
    public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
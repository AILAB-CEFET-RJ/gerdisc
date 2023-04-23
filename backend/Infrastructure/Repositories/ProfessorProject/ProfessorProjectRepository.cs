using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.ProfessorProject
{
    public class ProfessorProjectRepository : BaseRepository<ProfessorProjectEntity>, IProfessorProjectRepository
    {
        public ProfessorProjectRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
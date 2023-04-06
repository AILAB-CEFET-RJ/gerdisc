using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Professor
{
    public class ProfessorRepository : BaseRepository<ProfessorEntity>, IProfessorRepository
    {
        public ProfessorRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
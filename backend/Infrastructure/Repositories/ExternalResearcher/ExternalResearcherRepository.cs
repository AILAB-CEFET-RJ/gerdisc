using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.ExternalResearcher
{
    public class ExternalResearcherRepository : BaseRepository<ExternalResearcherEntity>, IExternalResearcherRepository
    {
        public ExternalResearcherRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.ExternalResearcher
{
    /// <inheritdoc />
    public class ExternalResearcherRepository : BaseRepository<ExternalResearcherEntity>, IExternalResearcherRepository
    {
        public ExternalResearcherRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
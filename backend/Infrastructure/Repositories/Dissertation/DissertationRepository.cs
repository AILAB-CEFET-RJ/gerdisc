using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Dissertation
{
    public class DissertationRepository : BaseRepository<DissertationEntity>, IDissertationRepository
    {
        public DissertationRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
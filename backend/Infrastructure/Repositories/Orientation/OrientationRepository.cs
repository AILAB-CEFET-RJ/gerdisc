using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Orientation
{
    public class OrientationRepository : BaseRepository<OrientationEntity>, IOrientationRepository
    {
        public OrientationRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
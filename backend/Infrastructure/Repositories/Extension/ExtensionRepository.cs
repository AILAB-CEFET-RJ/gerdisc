using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.Extension
{
    public class ExtensionRepository : BaseRepository<ExtensionEntity>, IExtensionRepository
    {
        public ExtensionRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
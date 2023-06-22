using gerdisc.Infrastructure.Extensions;
using gerdisc.Infrastructure.Providers;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.ResearchLine
{
    /// <inheritdoc />
    public class ResearchLineRepository : BaseRepository<ResearchLineEntity>, IResearchLineRepository
    {
        public ResearchLineRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
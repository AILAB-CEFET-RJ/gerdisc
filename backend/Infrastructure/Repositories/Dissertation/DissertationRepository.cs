using System.Linq.Expressions;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Repositories.Dissertation
{
    /// <inheritdoc />
    public class DissertationRepository : BaseRepository<DissertationEntity>, IDissertationRepository
    {
        public DissertationRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
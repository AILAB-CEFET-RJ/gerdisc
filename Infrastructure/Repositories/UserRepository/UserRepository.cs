using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
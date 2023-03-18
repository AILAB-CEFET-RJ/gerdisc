using gerdisc.Data.Entities;

namespace gerdisc.Repositories.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
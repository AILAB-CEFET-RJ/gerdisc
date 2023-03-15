 using gerdisc.Entities;

namespace gerdisc.Repositories.User
{
    public class UserRepository : BaseRepository<Entities.UserEntity>, IUserRepository
    {
        public UserRepository(ContexRepository dbContext) : base(dbContext)
        {
        }
    }
}
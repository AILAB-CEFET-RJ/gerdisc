using gerdisc.Infrastructure.Repositories.User;

namespace gerdisc.Infrastructure.Repositories
{
    public interface IRepository
    {
        public IUserRepository User{ get; }
    }
}
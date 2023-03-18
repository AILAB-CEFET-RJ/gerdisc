using gerdisc.Repositories.User;

namespace gerdisc.Repositories
{
    public interface IRepository
    {
        public IUserRepository User{ get; }
    }
}
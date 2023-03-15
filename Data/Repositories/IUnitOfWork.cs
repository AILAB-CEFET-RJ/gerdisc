using gerdisc.Repositories.User;

namespace gerdisc.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository User{ get; }
    }
}
using gerdisc.Infrastructure.Repositories.Course;
using gerdisc.Infrastructure.Repositories.Project;
using gerdisc.Infrastructure.Repositories.User;

namespace gerdisc.Infrastructure.Repositories
{
    public interface IRepository
    {
        public IUserRepository User{ get; }
        public IProjectRepository Project{ get; }
        public ICourseRepository Course{ get; }
        Task<int> CommitAsync();
    }
}
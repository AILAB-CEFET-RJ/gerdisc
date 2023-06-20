using gerdisc.Infrastructure.Repositories.Course;
using gerdisc.Infrastructure.Repositories.Dissertation;
using gerdisc.Infrastructure.Repositories.Extension;
using gerdisc.Infrastructure.Repositories.ExternalResearcher;
using gerdisc.Infrastructure.Repositories.Orientation;
using gerdisc.Infrastructure.Repositories.Professor;
using gerdisc.Infrastructure.Repositories.ProfessorProject;
using gerdisc.Infrastructure.Repositories.Project;
using gerdisc.Infrastructure.Repositories.Student;
using gerdisc.Infrastructure.Repositories.StudentCourse;
using gerdisc.Infrastructure.Repositories.User;

namespace gerdisc.Infrastructure.Repositories
{
    /// <summary>
    /// Access to all entities in the database.
    /// </summary>
    public class Repository : IRepository
    {
        public ContexRepository _dbContext;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Default constructor to create the data base context to access the database.
        /// </summary>
        /// <param name="server">Database url.</param>
        /// <param name="login">Database login.</param>
        /// <param name="password">Database password.</param>
        /// <param name="database">Database name.</param>
        public Repository(ContexRepository? dbContext, IUserContext userContext)
        {
            _userContext = userContext;
            if (dbContext is not null)
            {
                _dbContext = dbContext;
                _dbContext.Database.EnsureCreated();
            }
            else
            {
                throw new NullReferenceException("dbContext cannot be null.");
            }
        }

        public IUserRepository User => new UserRepository(_dbContext);
        public IStudentRepository Student => new StudentRepository(_dbContext);
        public IProfessorRepository Professor => new ProfessorRepository(_dbContext);
        public IProjectRepository Project => new ProjectRepository(_dbContext, _userContext);
        public IDissertationRepository Dissertation => new DissertationRepository(_dbContext);
        public IExtensionRepository Extension => new ExtensionRepository(_dbContext);
        public IExternalResearcherRepository ExternalResearcher => new ExternalResearcherRepository(_dbContext);
        public ICourseRepository Course => new CourseRepository(_dbContext);
        public IProfessorProjectRepository ProfessorProject => new ProfessorProjectRepository(_dbContext);
        public IStudentCourseRepository StudentCourse => new StudentCourseRepository(_dbContext);
        public IOrientationRepository Orientation => new OrientationRepository(_dbContext, _userContext);

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
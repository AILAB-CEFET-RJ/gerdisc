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
    /// Represents a repository interface that provides access to various entity repositories.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the repository for user entities.
        /// </summary>
        IUserRepository User { get; }

        /// <summary>
        /// Gets the repository for student entities.
        /// </summary>
        IStudentRepository Student { get; }

        /// <summary>
        /// Gets the repository for professor entities.
        /// </summary>
        IProfessorRepository Professor { get; }

        /// <summary>
        /// Gets the repository for project entities.
        /// </summary>
        IProjectRepository Project { get; }

        /// <summary>
        /// Gets the repository for dissertation entities.
        /// </summary>
        IDissertationRepository Dissertation { get; }

        /// <summary>
        /// Gets the repository for extension entities.
        /// </summary>
        IExtensionRepository Extension { get; }

        /// <summary>
        /// Gets the repository for external researcher entities.
        /// </summary>
        IExternalResearcherRepository ExternalResearcher { get; }

        /// <summary>
        /// Gets the repository for course entities.
        /// </summary>
        ICourseRepository Course { get; }

        /// <summary>
        /// Gets the repository for professor-project entities.
        /// </summary>
        IProfessorProjectRepository ProfessorProject { get; }

        /// <summary>
        /// Gets the repository for student-course entities.
        /// </summary>
        IStudentCourseRepository StudentCourse { get; }

        /// <summary>
        /// Gets the repository for orientation entities.
        /// </summary>
        IOrientationRepository Orientation { get; }

        /// <summary>
        /// Commits the pending changes asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous commit operation.</returns>
        Task<int> CommitAsync();
    }
}

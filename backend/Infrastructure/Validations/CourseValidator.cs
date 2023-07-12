using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    /// <summary>
    /// Provides validation methods for courses.
    /// </summary>
    public class CourseValidator
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseValidator"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public CourseValidator(IRepository repository)
        {
            _repository = repository;
        }
    }
}

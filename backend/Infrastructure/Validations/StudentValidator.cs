using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    /// <summary>
    /// Provides validation methods for students.
    /// </summary>
    public class StudentValidator
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentValidator"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public StudentValidator(IRepository repository)
        {
            _repository = repository;
        }
    }
}

using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    /// <summary>
    /// Provides validation methods for professors.
    /// </summary>
    public class ProfessorValidator
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessorValidator"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public ProfessorValidator(IRepository repository)
        {
            _repository = repository;
        }
    }
}

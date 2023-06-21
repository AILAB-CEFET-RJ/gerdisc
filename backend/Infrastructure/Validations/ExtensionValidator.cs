using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    /// <summary>
    /// Provides validation methods for extensions.
    /// </summary>
    public class ExtensionValidator
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionValidator"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public ExtensionValidator(IRepository repository)
        {
            _repository = repository;
        }
    }
}

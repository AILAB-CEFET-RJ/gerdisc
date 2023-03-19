using gerdisc.Infrastructure.Repositories.User;

namespace gerdisc.Infrastructure.Repositories
{
    /// <summary>
    /// Access to all entities in the database.
    /// </summary>
    public class Repository : IRepository
    {
        public ContexRepository _dbContext;

        /// <summary>
        /// Default constructor to create the data base context to access the database.
        /// </summary>
        /// <param name="server">Database url.</param>
        /// <param name="login">Database login.</param>
        /// <param name="password">Database password.</param>
        /// <param name="database">Database name.</param>
        public Repository(ContexRepository? dbContext)
        {
            if(dbContext is not null)
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
    }
}
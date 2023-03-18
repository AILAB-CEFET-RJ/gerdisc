using gerdisc.Repositories.User;

namespace gerdisc.Repositories
{
    /// <summary>
    /// Access to all entities in the database.
    /// </summary>
    public class Repository: IRepository
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
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public IUserRepository User => new UserRepository(_dbContext);
    }
}
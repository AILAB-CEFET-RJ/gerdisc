using gerdisc.Data.Entities;
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
            if (_dbContext.Users is not null && !_dbContext.Users.Any())
            {
                var myEntity = new UserEntity
                {
                    FirstName = "admin",
                    LastName = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                    Email = "admin@gmail.com",
                    Role = Data.Enums.RolesEnum.Administrator,
                    CreatedAt = DateTime.UtcNow
                };
                _dbContext.Users.Add(myEntity);
                _dbContext.SaveChanges();
            }
        }

        public IUserRepository User => new UserRepository(_dbContext);
    }
}
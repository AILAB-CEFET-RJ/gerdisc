using gerdisc.Entities;
using gerdisc.Repositories.User;

namespace gerdisc.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public ContexRepository _dbContext;

        public UnitOfWork(string server, string login, string password, string database)
        {
            _dbContext = new ContexRepository(server, login, password, database);
            _dbContext.Database.EnsureCreated();
            if (!_dbContext.Users.Any())
            {
                var myEntity = new UserEntity
                {
                    Id = 1,
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
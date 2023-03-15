using gerdisc.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Repositories
{
    public class ContexRepository : DbContext
    {
        public string? DbUrl { get; }

        public DbSet<Entities.UserEntity> Users { get; set; }

        public ContexRepository(string server, string login, string password, string database)
        {
            DbUrl = $"Host={server};Username={login};Password={password};Database={database}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(DbUrl);
    }
}

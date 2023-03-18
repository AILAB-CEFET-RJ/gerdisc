using gerdisc.Data.Entities;
using gerdisc.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Repositories
{
    public class ContexRepository : DbContext
    {
        public string? DbUrl { get; }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<ProfessorEntity> Professors { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }


        public ContexRepository(DbContextOptions<ContexRepository> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<StudentEntity>().ToTable("Students");
            modelBuilder.Entity<ProfessorEntity>().ToTable("Professors");
            modelBuilder.Entity<CourseEntity>().ToTable("Courses");
        }
    }
}
